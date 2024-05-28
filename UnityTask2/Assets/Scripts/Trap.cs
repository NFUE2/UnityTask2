using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, IPrompt
{
    public float damage;
    public string trapName;

    public string promptName => trapName;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out IChangeHP damagable))
        {
            damagable.Change(-damage);
        }
    }
}
