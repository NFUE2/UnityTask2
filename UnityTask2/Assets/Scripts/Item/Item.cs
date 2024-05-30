using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public ItemData data;
    public string message => data.itemName;

    public virtual void Interaction(Player player) { }
}