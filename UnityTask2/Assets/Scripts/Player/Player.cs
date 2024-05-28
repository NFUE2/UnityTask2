using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour,IDamagable
{
    public Condition playerHP;

    public float HP;

    private void Start()
    {
        playerHP.maxValue = HP;
    }

    public void TakeDamage(float damage)
    {
        playerHP.curValue -= damage;
    }
}
