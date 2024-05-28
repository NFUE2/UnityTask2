using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IChangeHP
{
    public Condition playerHP;
    public float HP;

    private void Start()
    {
        playerHP.maxValue = HP;
    }

    public void Change(float damage)
    {
        playerHP.curValue = Mathf.Clamp(playerHP.curValue + damage,0,playerHP.maxValue);
    }
}
