using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpPotion : Item, IUseItem,IEffectUI
{
    public float maxTime => (data as ReinforcePotionData).maxTime;
    public Sprite icon => (data as ReinforcePotionData).icon;

    float value;
    Player player;



    private void Start()
    {
        player = GameManager.instance.player;
        value = (data as PotionData).value * player.data.speed;
    }

    public float curTime
    {
        get => (data as ReinforcePotionData).curTime;
        set => (data as ReinforcePotionData).curTime = value;
    }

    public void UseItem()
    {
        player.GetEffect(this);
    }

    public void ApplyEffect()
    {
       player.data.speed += value;
       
    }

    public void RemoveEffect()
    {
        player.data.speed -= value;
    }
}