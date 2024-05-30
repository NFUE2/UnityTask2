using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpPotion : Item, IEffectUI
{
    public float maxTime => (data as ReinforcePotionData).maxTime;
    public Sprite icon => (data as ReinforcePotionData).icon;

    float value;
    Player player;

    public float curTime
    {
        get => (data as ReinforcePotionData).curTime;
        set => (data as ReinforcePotionData).curTime = value;
    }

    public override void Interaction(Player player)
    {
        if (value == 0.0f) value = (data as PotionData).value * player.data.speed;

        this.player = player;
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