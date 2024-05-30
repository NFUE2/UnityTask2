using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentAttribute
{
    public EquipType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "item/Equipment")]
public class EquipData : ItemData
{
    public EquipmentAttribute[] attribute;

}
