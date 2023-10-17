using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopPlayer : MonoBehaviour
{

    #region Unity methods
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCameraRotation(Input.mousePosition);
        }

        if (Input.GetMouseButton(1))
        {
            UpdateCameraRotation(Input.mousePosition);
        }

        UpdatePlayerPosition(new Vector2( Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0, Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0), Input.GetKeyDown(KeyCode.Space), Input.GetKey(KeyCode.LeftShift));

    }
    #endregion


    #region Camera rotation
    [Header("Camera")]
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private float cameraSpeed = 3;

    private Vector3 lastMousePos;

    private void StartCameraRotation(Vector3 mousePose)
    {
        lastMousePos = mousePose;
    }

    private void UpdateCameraRotation(Vector3 mousePose)
    {
        Vector3 movement = mousePose - lastMousePos;
        lastMousePos = mousePose;

        cameraTransform.eulerAngles += (new Vector3(-movement.y, movement.x, 0) * (Time.deltaTime * cameraSpeed));
    }
    #endregion


    #region Player movement
    [Header("Movement")]
    [SerializeField]
    private Rigidbody rigidBody;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float jump = 200;

    private void UpdatePlayerPosition(Vector2 dir, bool fly, bool turbo)
    {
        if (dir.x != 0)
        {
            transform.position += new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z) * (Time.deltaTime * (dir.x > 0 ? speed : -speed) * (turbo ? 2 : 1));
        }

        if (dir.y != 0)
        {
            transform.position += new Vector3(cameraTransform.right.x, 0, cameraTransform.right.z) * (Time.deltaTime * (dir.y > 0 ? speed : -speed) * (turbo ? 2 : 1));
        }

        if (fly)
        {
            rigidBody.AddForce(Vector3.up * jump);
        }
    }
    #endregion

}
