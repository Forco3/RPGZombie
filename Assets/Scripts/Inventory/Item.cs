using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newItem", menuName = "Item")]

public class Item : ScriptableObject
{
    public string nameItem; //�����
    public Sprite spriteItem; //��������
    public ItemType itemType;
}
public enum ItemType
{
    None,
    Weapon,
    Heal,
    Bullets,
    Armor,
    Foood,
    Drink,
    Other
}