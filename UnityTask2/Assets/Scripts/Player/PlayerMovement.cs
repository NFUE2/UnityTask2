using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;

    [Header("Move")]
    private Vector2 direction;
    public float speed = 5.0f;

    public float jumpPower;
    public LayerMask groundlayer;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void FixedUpdate()
    {
        Moving();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        Vector3 value = context.ReadValue<Vector2>();

        if (context.phase == InputActionPhase.Performed)
            direction = context.ReadValue<Vector2>();

        else
            direction = Vector3.zero;
    }

    private void Moving()
    {
        Vector3 dir = (transform.forward * direction.y + transform.right * direction.x) * speed;
        dir.y = rigidbody.velocity.y;
        rigidbody.velocity = dir;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && !IsJumping())
        {
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private bool IsJumping()
    {
        Ray[] ray = new Ray[4]
        {
            new Ray(transform.position + transform.up * 0.01f + transform.forward * 0.01f,Vector3.down),
            new Ray(transform.position + transform.up * 0.01f + -transform.forward * 0.01f,Vector3.down),
            new Ray(transform.position + transform.up * 0.01f + transform.right * 0.01f,Vector3.down),
            new Ray(transform.position + transform.up * 0.01f + -transform.right * 0.01f,Vector3.down),
        };

        for (int i = 0; i < ray.Length; i++)
        {
            if (Physics.Raycast(ray[i], 0.1f, groundlayer))
                return false;
        }

        return true;
    }
}
