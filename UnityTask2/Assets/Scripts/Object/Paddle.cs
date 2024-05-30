using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody paddle,player;
    Vector3 direction;

    public Transform[] rallyPoint;
    public int curTargetPoint;

    public float speed;

    private void Awake()
    {
        paddle = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.TryGetComponent(out player);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) player = null;
    }

    private void Update()
    {
        if (Vector3.Distance(paddle.position, rallyPoint[curTargetPoint].position) < 1f)
        {
            curTargetPoint = (curTargetPoint + 1) % rallyPoint.Length;
            direction = (rallyPoint[curTargetPoint].position - paddle.position).normalized * speed;
        }
    }

    private void FixedUpdate()
    {
        Vector3 dir = direction * Time.fixedDeltaTime;

        paddle.MovePosition(paddle.position + dir);

        if (player != null) player.MovePosition(player.position + dir);
    }
}
