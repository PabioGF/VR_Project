using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandControllersManager : MonoBehaviour
{

    #region Unity methods
    private void Awake()
    {
        InitTeleportInteractorEvents();
    }

    private void Start()
    {
        InitInteractors();
    }

    private void OnDestroy()
    {
        RemoveTeleportInteractorEvents();
    }
    #endregion


    #region Interactors Manager
    public enum InteractorAtive { None, UiInteractor, TeleportInteractor }
    [Header("Interactors Managment")]
    [SerializeField]
    private InteractorAtive activeInteractor = InteractorAtive.None;

    private void InitInteractors()
    {
        SetInteractorActive(GetDefaultInteractor());
    }

    private void SetInteractorActive(InteractorAtive _activeInteractor)
    {
        //No changes
        if (activeInteractor == _activeInteractor) return;

        //Set new interactor state
        activeInteractor = _activeInteractor;

        //Apply interactors configuration
        switch (activeInteractor)
        {
            case InteractorAtive.UiInteractor:
                SetRayInteractorActive(true);
                SetTeleportInteractorActive(false);
                break;
            
            case InteractorAtive.TeleportInteractor:
                SetRayInteractorActive(false);
                SetTeleportInteractorActive(true);
                break;

            case InteractorAtive.None:
                SetRayInteractorActive(false);
                SetTeleportInteractorActive(false);
                break;
        }
    }

    private InteractorAtive GetDefaultInteractor()
    {
        return InteractorAtive.UiInteractor;
    }
    #endregion


    #region Teleportation Interactor
    [Header("Teleportation")]
    [SerializeField]
    private XRRayInteractor teleportInteractor;
    [SerializeField]
    private InputActionReference teleportActivate;

    private TeleportationArea teleportArea;

    private void InitTeleportInteractorEvents()
    {
        //Detect user started teleportation
        if (teleportActivate.action != null)
        {
            teleportActivate.action.performed += OnTeleportStart;
            teleportActivate.action.canceled += OnTeleportCanceled;
        }

    }

    private void RemoveTeleportInteractorEvents()
    {
        //Remove event listeners 
        if (teleportActivate.action != null)
        {
            teleportActivate.action.performed -= OnTeleportStart;
            teleportActivate.action.canceled -= OnTeleportCanceled;
        }

    }

    private void OnTeleportStart(InputAction.CallbackContext context)
    {
        //Teleport is not allowed while a Interactable object is selected
        if (HasInteractableObjectSelected()) { return; }

        SetInteractorActive(InteractorAtive.TeleportInteractor);
    }

    private void OnTeleportEnd(TeleportingEventArgs arg0)
    {
        if (teleportArea != null) teleportArea.teleporting.RemoveListener(OnTeleportEnd);
        SetInteractorActive(GetDefaultInteractor());
    }

    private void OnTeleportCanceled(InputAction.CallbackContext context)
    {
        //We check if any of the classes that the ray has are a teleport area, if so we return.
        if (teleportInteractor.interactablesHovered.Count > 0)
        {
            foreach (IXRHoverInteractable interactableObj in teleportInteractor.interactablesHovered)
            {
                if (interactableObj is TeleportationArea) 
                {
                    teleportArea = interactableObj as TeleportationArea;
                    teleportArea.teleporting.AddListener(OnTeleportEnd);
                    return; 
                }
            }    
        }

        SetInteractorActive(GetDefaultInteractor());

    }

    private void SetTeleportInteractorActive(bool active)
    {
        teleportInteractor.gameObject.SetActive(active);
    }
    #endregion


    #region Ray Interactor
    [Header("Ray Interactor")]
    [SerializeField]
    private XRRayInteractor rayInteractor;

    private void SetRayInteractorActive(bool active)
    {
        rayInteractor.gameObject.SetActive(active);
    }

    private bool HasInteractableObjectSelected()
    {        
        return rayInteractor.interactablesSelected.Count > 0;
    }
    #endregion

}
