using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpObejct : MonoBehaviour
{
    public float jumpPower;

    private void OnCollisionEnter(Collision collision)
    {
        bool isTread = collision.contacts[0].normal.y < 0;

        if (isTread && collision.gameObject.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}
