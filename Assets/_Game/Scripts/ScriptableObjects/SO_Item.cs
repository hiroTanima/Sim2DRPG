using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Body,
    Hair,
    Outfit
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 0)]
public class SO_Item : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public int itemIndex;
    public Sprite itemIcon;
    public float itemPrice;

    public AnimationClip idle_Down, idle_Left, idle_Right, idle_Up;
    public AnimationClip walk_Down, walk_Left, walk_Right, walk_Up;
}
