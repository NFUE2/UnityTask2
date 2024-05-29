using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour, IChangeHP
{
    public PlayerData data;

    public Image buffPrefab;

    public Transform buffTransfrom;
    public Condition playerHP;
    public float HP;

    public event Action OnChangeStatEvent;

    public List<Item> items = new List<Item>();
    public List<IEffectUI> itemEffect = new List<IEffectUI>();


    private void Start()
    {
        playerHP.maxValue = HP;
        OnChangeStatEvent?.Invoke();
    }

    public void Change(float damage)
    {
        playerHP.curValue = Mathf.Clamp(playerHP.curValue + damage,0,playerHP.maxValue);
    }

    public void GetEffect(IEffectUI ui)
    {
        if (itemEffect.Contains(ui)) return;

        Image go = Instantiate(buffPrefab,buffTransfrom);
        go.GetComponent<UIicon>().effect = ui;
        go.sprite = ui.icon;

        ui.ApplyEffect();

        OnChangeStatEvent?.Invoke();
        
        itemEffect.Add(ui);
    }

    public void RemoveEffect(IEffectUI ui)
    {
        ui.RemoveEffect();

        OnChangeStatEvent?.Invoke();

        itemEffect.Remove(ui);
    }

    public void EquipItem()
    {

    }

    public void UnEquip()
    {

    }
}
