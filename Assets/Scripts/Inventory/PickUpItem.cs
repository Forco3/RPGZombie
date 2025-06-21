using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Item itemData;
    private Inventory inventory;
    private MoveChar myPerson;
    private Transform newItem;
    public float minDist = 1.5f;
    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        newItem = GetComponent<Transform>();
        myPerson = FindObjectOfType<MoveChar>();
    }
    public void Interected()
    {
        float distance = Vector3.Distance(myPerson.transform.position, newItem.position); //получаем текущее расстояние между игроком и объектом
        if (itemData != null && distance <= minDist)
        {
            inventory.AddItem(itemData);
            gameObject.SetActive(false);
        }
    }
    public bool IsWeapon()
    {
        if (itemData.nameItem == "M16")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
