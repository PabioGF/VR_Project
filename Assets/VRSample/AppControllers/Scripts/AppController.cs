using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class AppController : MonoBehaviour
{


    #region Unity methods
    private void Awake()
    {
        SetupPlatform();
    }
    #endregion


    #region VR Devices
    public static bool VRDeviceConnected()
    {

        List<XRDisplaySubsystem> displaySubsystems = new List<XRDisplaySubsystem>();

        SubsystemManager.GetInstances<XRDisplaySubsystem>(displaySubsystems);

        return displaySubsystems.Count > 0;
    }
    #endregion


    #region App platform configuration
    [Header("App platform configuration")]
    [SerializeField]
    private GameObject vrPlayer;
    [SerializeField]
    private GameObject desktopPlayer;
    [SerializeField]
    private Camera desktopCamera;

    private void SetupPlatform() 
    {
        bool isVR = VRDeviceConnected();
        desktopPlayer.SetActive(!isVR);
        vrPlayer.SetActive(isVR);

        if (!isVR)
        {
            TrackedDeviceGraphicRaycaster[] canvasRaycasters = FindObjectsOfType<TrackedDeviceGraphicRaycaster>(true);

            foreach (var canvasRaycaster in canvasRaycasters)
            {
                canvasRaycaster.enabled = false;
                canvasRaycaster.GetComponent<Canvas>().worldCamera = desktopCamera;
            }

        }
        

    }
    #endregion

}
