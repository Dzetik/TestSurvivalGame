using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType { Food, Weapon, Armor, Other, Forge }

public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public GameObject itemPrefab;
    public Sprite icon;
    public ItemType itemType;
    public string itemDescription;
    public double weight;

}
