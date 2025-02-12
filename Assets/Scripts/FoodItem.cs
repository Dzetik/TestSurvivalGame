using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// позволение создавать объекты FoodItem через пкм
[CreateAssetMenu(fileName = "Food Item", menuName = "Inventory/Items/Food Item")]
public class FoodItem : ItemScriptableObject
{
    public int healAmount;
    public int timeOfLife;

    private void Start()
    {
        itemType = ItemType.Food;
    }

}
