using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType
{
    Speed,
    Jump
}

public abstract class Equipment : Item
{
    protected Player player;

   public abstract void Equip();
   public abstract void UnEquip();
}
