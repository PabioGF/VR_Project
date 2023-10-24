using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LanternController : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    [SerializeField] private InputActionReference clickAction;
    private bool _lightOn;
    public bool _isOnHand;

    void Awake()
    {
        RegisterClick();
    }

    private void OnDestroy()
    {
        UnRegisterClick();
    }

    void Update()
    {

    }

    private void RegisterClick()
    {
        clickAction.action.performed += OnClickDown;
    }

    private void UnRegisterClick()
    {
        clickAction.action.performed -= OnClickDown;
    }

    private void OnClickDown(InputAction.CallbackContext args)
    {
        Debug.Log("CLick");
        if (!_isOnHand) { return; }

        if (!_lightOn)
        {
            _light.SetActive(true);
        }
        else
        {
            _light.SetActive(false);
        }
    }
}
