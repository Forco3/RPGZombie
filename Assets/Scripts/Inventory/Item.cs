using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newItem", menuName = "Item")]

public class Item : ScriptableObject
{
    public string nameItem; //текст
    public Sprite spriteItem; //картинка
}
