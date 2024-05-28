using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, IPrompt
{
    public float damage;

    public string trapName;

    public string promptName { get => trapName; }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(damage);
        }
    }
}
