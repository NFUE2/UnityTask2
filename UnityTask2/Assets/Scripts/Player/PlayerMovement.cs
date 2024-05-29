using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//enum PlayerState
//{
//    Walk,
//    Climb,
//}

public class PlayerMovement : MonoBehaviour,IChangeStat
{
    private Rigidbody rigidbody;
    private Player player;

    [Header("Move")]
    private Vector2 direction;
    public float speed;

    private float jumpPower;
    public LayerMask groundlayer;
    public LayerMask climblayer;

    //PlayerState state = PlayerState.Walk;

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
        //if (state == PlayerState.Climb) Climing();
        //else Moving();
        Moving();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        Vector3 value = context.ReadValue<Vector2>();

        if (context.phase == InputActionPhase.Performed)
            direction = context.ReadValue<Vector2>();

        else
            direction = Vector3.zero;

        //if (isClimb())
        //{
        //    state = PlayerState.Climb;
        //    rigidbody.useGravity = false;
        //    rigidbody.velocity = Vector3.zero;
        //}
    }

    private void Moving()
    {
        Vector3 dir = (transform.forward * direction.y + transform.right * direction.x) * speed;
        dir.y = rigidbody.velocity.y;
        rigidbody.velocity = dir;
    }

    private void Climing()
    {
        Vector3 dir = Vector3.zero + new Vector3(0,transform.position.y,0);

        rigidbody.MovePosition(transform.position + dir * 1.0f * Time.fixedDeltaTime);
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

    private bool isClimb()
    {

        Ray[] ray = new Ray[2]
        {
            new Ray(transform.position + Vector3.up * 0.01f,Vector3.forward),
            new Ray(transform.position + Vector3.up * 1.5f,Vector3.forward)
        };
        for (int i = 0; i < ray.Length; i++)
        {
            if(!Physics.Raycast(ray[i],1f,climblayer))
            {
                return false;
            }
        }
        return true;
    }
}
