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

    // Start is called before the first frame update
    void Start()
    {
        curValue = maxValue;
    }

    // Update is called once per frame
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
