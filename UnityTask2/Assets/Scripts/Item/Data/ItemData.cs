using UnityEngine;

[CreateAssetMenu(fileName = "Item",menuName = "Item")]
public class ItemData : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public string description;

    public bool canStack;
    public int maxStack;
}
