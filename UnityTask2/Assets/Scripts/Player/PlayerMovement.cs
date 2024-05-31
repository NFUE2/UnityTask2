using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour,IChangeStat
{
    private Rigidbody rigidbody;
    private Player player;


    [Header("Move")]
    private Vector2 direction;
    public float speed;
    public Transform character;

    private float jumpPower;
    public LayerMask groundlayer;
    public LayerMask climblayer;

    public Transform camera;

    bool isClimb;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidbody = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        player.OnChangeStatEvent += ChangeStat;
    }

    private void Start()
    {
        jumpPower = player.data.jumpPower;
    }

    private void FixedUpdate()
    {

        if (!isClimb) Moving();
        else Climbing();
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
        
        Vector3 dir = (camera.transform.forward * direction.y + camera.transform.right * direction.x) * speed;

        dir.y = rigidbody.velocity.y;
        rigidbody.velocity = dir;

        character.localEulerAngles = new Vector3(0, camera.localEulerAngles.y, 0);

        if (direction.y > 0 && IsClimb())
        {
            isClimb = true;
            character.localEulerAngles = new Vector3(0, camera.localEulerAngles.y, 0);
            //rigidbody.velocity = Vector2.zero;
        }
    }

    private void Climbing()
    {
        rigidbody.AddForce(character.forward,ForceMode.VelocityChange);
        Vector3 dir = (transform.up * direction.y + transform.right * direction.x) * speed;

        rigidbody.velocity = dir;

        if ((!IsClimb() || !IsJumping()) && direction.y < 0) isClimb = false;
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

    public void ChangeStat()
    {
        speed = player.data.speed;
    }

    private bool IsClimb()
    {

        Ray[] ray = new Ray[2]
        {
            new Ray(character.position + character.up * 0.1f,character.forward),
            new Ray(character.position + character.up * 1.5f,character.forward)
        };

        for (int i = 0; i < ray.Length; i++)
        {
            if(!Physics.Raycast(ray[i],0.5f,climblayer))
            {
                return false;
            }
        }
        return true;
    }
}
