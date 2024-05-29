using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ReinforcePotion", menuName = "Potion/ReinforcePotion", order = 1)]
public class ReinforcePotionData : PotionData
{
    [Header("Reinforce")]
    public float maxTime;
    public float curTime;
    public Sprite icon;
}
