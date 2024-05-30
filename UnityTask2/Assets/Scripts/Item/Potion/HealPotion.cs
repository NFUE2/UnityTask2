using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : Item
{
    public override void Interaction(Player player)
    {
        PotionData potionData = data as PotionData;
        player.GetComponent<IChangeHP>().Change(potionData.value);
    }
}
