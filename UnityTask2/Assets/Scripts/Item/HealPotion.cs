using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : Item, IUseItem
{
    public void UseItem()
    {
        PotionData potionData = data as PotionData;
        IChangeHP player = GameManager.instance.player.GetComponent<IChangeHP>();

        player.Change(potionData.value);
    }
}
