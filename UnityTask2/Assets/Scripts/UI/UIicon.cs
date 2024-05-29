using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIicon : MonoBehaviour
{
    Image icon;
    float value,time;
    public IEffectUI effect;
    public AnimationCurve curve;

    private void Start()
    {
        icon = GetComponent<Image>();
        effect.curTime = 0.0f;
    }

    private void Update()
    {
        effect.curTime += Time.deltaTime;

        time = effect.curTime / effect.maxTime;
        value = curve.Evaluate(time);

        icon.color = new Color(1, 1, 1, value);

        if (value <= 0) RemoveEffect();
    }

    void RemoveEffect()
    {
        GameManager.instance.player.RemoveEffect(effect);
        Destroy(gameObject);
    }
}
