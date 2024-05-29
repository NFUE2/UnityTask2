using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody paddle,player;
    Vector3 direction;

    public float speed;

    private void Awake()
    {
        paddle = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        bool boarding = collision.contacts[0].normal == Vector3.down;

        if (collision.gameObject.TryGetComponent(out player) && boarding)
            direction = transform.forward * speed;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
            direction = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        Vector3 dir = direction * Time.fixedDeltaTime;

        paddle.MovePosition(transform.position + dir);
        if (player != null) player.MovePosition(player.position + dir);
    }
}
