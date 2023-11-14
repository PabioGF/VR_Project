using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAttachLantern : MonoBehaviour
{
    private LanternController _lanternController;
    private bool _inHand;

    #region Unity methods
    private void Awake()
    {
        InitComponents();
        _lanternController = gameObject.GetComponent<LanternController>();
    }

    private void OnEnable()
    {
        AddListeners();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }
    #endregion


    #region Interactable Events
    private XRGrabInteractable selectInteractable;

    private void InitComponents()
    {
        selectInteractable = GetComponent<XRGrabInteractable>();
    }

    private void AddListeners()
    {
        selectInteractable.selectEntered.AddListener(OnSelected);
    }

    private void RemoveListeners()
    {
        selectInteractable.selectEntered.RemoveListener(OnSelected);
    }

    private void OnSelected(SelectEnterEventArgs args)
    {        
        SetOnMyHand(args.interactorObject);
        
    }
    #endregion


    #region Set GameObject on my hand 
    private void SetOnMyHand(IXRSelectInteractor interactor)
    {
        Transform attachTransform = interactor.GetAttachTransform(selectInteractable);
        Pose attachPose = interactor.GetLocalAttachPoseOnSelect(selectInteractable);
        attachTransform.localPosition = attachPose.position;
        attachTransform.localRotation = attachPose.rotation;

        _lanternController._isOnHand = true;
    }
    #endregion

}
