using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damage;

    //public string trapName;
    //public string message => trapName;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out IChangeHP player))
        {
            player.Change(-damage);
        }
    }
}
