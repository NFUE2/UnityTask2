using UnityEngine;

[CreateAssetMenu(fileName = "Item",menuName = "item/item")]
public class ItemData : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public string description;

    public bool canStack;
    public int maxStack;
}
