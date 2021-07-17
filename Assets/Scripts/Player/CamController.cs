using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] private float senX = 30f;
    [SerializeField] private float senY = 25f;

    private float multiplier = 0.1f;

    [SerializeField] Camera cam = null;
    [SerializeField] Transform orientation = null;
    [SerializeField] Transform camRot = null;

    float RotationX;
    float RotationY;
    float MouseX;
    float MouseY;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        MouseX = Input.GetAxisRaw("Mouse X");
        MouseY = Input.GetAxisRaw("Mouse Y");

        RotationX += MouseY * senY * multiplier;
        RotationY -= MouseX * senX * multiplier;

        RotationX = Mathf.Clamp(RotationX, -90, 90);

        camRot.rotation = Quaternion.Euler(-RotationX, -RotationY, 0);
        orientation.rotation = Quaternion.Euler(-camRot.rotation.x, -RotationY, 0);

    }
}
