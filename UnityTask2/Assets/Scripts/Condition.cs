using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float maxValue;

    public TextMeshProUGUI valueText;
    public Image uiBar;

    void Start()
    {
        curValue = maxValue;
    }

    void Update()
    {
        uiBar.fillAmount = GetPercent();
        valueText.text = $"{curValue} / {maxValue}";
    }

    float GetPercent()
    {
        return curValue / maxValue;
    }
}
