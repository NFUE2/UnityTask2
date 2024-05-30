using UnityEngine;

public enum PotionType
{
    HP,
    MP,
    Stamina,
    Reinforcement
}

[CreateAssetMenu(fileName = "Potion",menuName = "item/Potion",order = 0)]
public class PotionData : ItemData
{
    [Header("Potion")]
    public float value;
    public PotionType type;
}
