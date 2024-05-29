using UnityEngine;

public interface IEffectUI
{
    float maxTime { get; }
    float curTime { get; set; }
    Sprite icon { get; }

    void ApplyEffect();
    void RemoveEffect();
}
