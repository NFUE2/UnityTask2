using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSight : MonoBehaviour
{
    [Header("Look")]
    private Vector2 mouseDirection;
    public float rotIntesity = 1.0f;
    private float minAngle = -85f, maxAngle = 85f, rotX;
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void LateUpdate()
    {
        Look();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDirection = context.ReadValue<Vector2>();
    }

    private void Look()
    {
        rotX += mouseDirection.y * rotIntesity;
        rotX = Mathf.Clamp(rotX, minAngle, maxAngle);
        camera.transform.localEulerAngles = new Vector3(-rotX, 0, 0);

        transform.localEulerAngles += new Vector3(0, mouseDirection.x, 0);
    }
}
