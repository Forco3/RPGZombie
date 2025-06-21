using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image slotImage;
    private ItemInSlot itemInSlot;
    private void Awake()
    {
        slotImage = GetComponent<Image>();
        itemInSlot = GetComponentInChildren<ItemInSlot>();
    }
    public void SetItem(Item newItem)
    {
        itemInSlot.SetDataItem(newItem);
    }
    public void ResetItem()
    {
        itemInSlot.ResetDataItem();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        slotImage.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        slotImage.color = Color.grey;
    }
}
