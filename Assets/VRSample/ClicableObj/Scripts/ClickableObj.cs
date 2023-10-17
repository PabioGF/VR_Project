using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[ExecuteInEditMode]
public class ClickableObj : MonoBehaviour, IXRHoverInteractable
{

    #region Unity methods
    private void Awake()
    {    
        RegisterInteractable();
        RegisterClick();
    }

    private void OnDestroy()
    {
        UnRegisterInteractable();
        UnRegisterClick();
    }
    #endregion


    #region Auto Init
    [ContextMenu(nameof(InitComponets))]
    private void InitComponets() 
    {
        manager = FindObjectOfType<XRInteractionManager>();
        _colliders = new List<Collider>(GetComponentsInChildren<Collider>());
        layerMask.value = InteractionLayerMask.GetMask("Default");
        
    }
    #endregion


    #region Registration
    [Header("Manager")]
    [SerializeField]
    private XRInteractionManager manager;

    public event Action<InteractableRegisteredEventArgs> registered;
    public event Action<InteractableUnregisteredEventArgs> unregistered;

    private void RegisterInteractable()
    {
        manager.RegisterInteractable(this);
    }

    private void UnRegisterInteractable()
    {
        manager.UnregisterInteractable(this);
    }
    #endregion


    #region Configuration
    [Header("Configuration")]
    [SerializeField]
    private InteractionLayerMask layerMask;
    [SerializeField]
    private List<Collider> _colliders = new List<Collider>();


    public List<Collider> colliders => _colliders;
    public InteractionLayerMask interactionLayers => layerMask;
    #endregion


    #region Click detection
    [Header("Click input")]
    [SerializeField]
    private InputActionReference clickAction;

    private bool readyToClick = false;

    private void RegisterClick()
    {
        clickAction.action.performed += OnClickDown;
        clickAction.action.canceled += OnClickUp;
    }

    private void UnRegisterClick()
    {
        clickAction.action.performed -= OnClickDown;
        clickAction.action.canceled -= OnClickUp;
    }

    private void OnClickDown(InputAction.CallbackContext args)
    {
        if (isHover) { readyToClick = true; }
    }

    private void OnClickUp(InputAction.CallbackContext args)
    {
        if (isHover && readyToClick) 
        {
            onClick.Invoke();
        }
    }

    private void CancelClickAction()
    {
        readyToClick = false;
    }

    //Set click action for non VR setup
    private void OnMouseUpAsButton()
    {
        onClick.Invoke();
    }
    #endregion


    #region Interface properties
    private List<IXRHoverInteractor> interactors = new List<IXRHoverInteractor>();
    public List<IXRHoverInteractor> interactorsHovering => interactors;

    private bool isHover { get { return interactorsHovering.Count > 0; } }
    public bool isHovered => isHover;
    
    public Transform GetAttachTransform(IXRInteractor interactor)
    {
        return transform;
    }

    public float GetDistanceSqrToInteractor(IXRInteractor interactor)
    {
        return Vector3.Distance(interactor.transform.position, transform.position);
    }
    public bool IsHoverableBy(IXRHoverInteractor interactor)
    {
        return true;
    }
    #endregion


    #region Interaction methods
    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        onHoverEnter.Invoke();
        interactors.Add(args.interactorObject);
    }

    public void OnHoverEntering(HoverEnterEventArgs args)
    {
    
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        onHoverExit.Invoke();
        interactors.Remove(args.interactorObject);
        CancelClickAction();
    }

    private void OnMouseEnter()
    {
        onHoverEnter.Invoke();
    }

    private void OnMouseExit()
    {
        onHoverExit.Invoke();
    }

    public void OnHoverExiting(HoverExitEventArgs args)
    {

    }

    public void OnRegistered(InteractableRegisteredEventArgs args)
    {

    }

    public void OnUnregistered(InteractableUnregisteredEventArgs args)
    {

    }

    public void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {

    }
    #endregion


    #region Events
    [Header("Events")]
    public UnityEvent onHoverEnter;
    public UnityEvent onHoverExit;
    public UnityEvent onClick;

    public HoverEnterEvent firstHoverEntered => new HoverEnterEvent();
    public HoverExitEvent lastHoverExited => new HoverExitEvent();
    public HoverEnterEvent hoverEntered => new HoverEnterEvent();
    public HoverExitEvent hoverExited => new HoverExitEvent();
    #endregion

}

