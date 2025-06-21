using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Slot> slots = new List<Slot>();
    private List<ItemInSlot> items = new List<ItemInSlot>();
    private void Awake()
    {
        slots.AddRange(FindObjectsOfType<Slot>(false));
        items.AddRange(FindObjectsOfType<ItemInSlot>(false));
    }
    public void AddItem(Item pickUpItem)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (items[i].itemData == null)
            {
                slots[i].SetItem(pickUpItem);
                Debug.Log("Slot " + i);
                return;
            }
        }
            
    }
}
