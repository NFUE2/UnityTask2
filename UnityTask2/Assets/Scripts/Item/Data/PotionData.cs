using UnityEngine;
using UnityEngine.UI;


public enum PotionType
{
    HP,
    MP,
    Stamina,
    Reinforcement
}

[CreateAssetMenu(fileName = "Posion",menuName = "Postion")]
public class PotionData : ItemData
{
    [Header("Potion")]
    public int value;
    public PotionType type;
    public Image icon;
}
