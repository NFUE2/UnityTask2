using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPrompt
{
    public ItemData data;
    public string promptName => data.itemName;
}
