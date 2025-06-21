using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemInSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler 
{
    private CharacterState charSt;
    private Canvas canvas;
    private RectTransform rectTransform; //RectTransform- необходим для UI 2d объектов
    private Transform originalParent; //Компонент Transform у родителя (Slot)
    private CanvasGroup canvasGroup;
    public Item itemData {  get; private set; }
    private Image imageItem;
    private TextMeshProUGUI textItem;
    private float timer;
    private float doubleClick = 0.3f;
    private float lastClickTime;
    private bool isDoubleClick;
    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        imageItem = GetComponent<Image>();
        textItem = GetComponentInChildren<TextMeshProUGUI>();
        charSt = FindObjectOfType<CharacterState>();
        
    }
    public void SetDataItem(Item newItemData)
    {
        itemData = newItemData;
        imageItem.sprite = itemData.spriteItem; //записываем данные (картинку подобранного предмета) в компонент Image
        textItem.text = itemData.nameItem;
    }
    public void ResetDataItem()
    {
        itemData = null;
        imageItem.sprite = null;
        textItem.text = "";
    }
    public void OnBeginDrag(PointerEventData eventData) //PointerEventData- класс, отвечающий за курсор мышки (обрабатывает позицию курсора мышки, его наведение и клики)
    {
        canvasGroup.blocksRaycasts = false; //Выключаем блокировку луча, чтобы не припятствовать обнаружению ячеек
        canvasGroup.alpha = 0.5f; //Устанавливаем прозрачность объекта на курсоре (в данном случае уменьшаем)
        originalParent = transform.parent; //Получаем компонент Transform родителя объекта Slot
        rectTransform.SetParent(canvas.transform); //Устанавливаем нового родителя Canvas
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; //делим смещение курсора мышки на размер UI холста //anchoredPosition- позиция в 2d (Vector2) пространстве
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; 
        canvasGroup.alpha = 1; //Устанавливаем прозрачность объекта на курсоре (в данном случае увеличиваем обратно до 1)
        rectTransform.SetParent(originalParent); //Возвращаем родителя для объекта на курсоре
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            HandlerClick();
           
        }
    }
    private void HandlerClick()
    {
        float timeLastClick = Time.time - lastClickTime;
        if (timeLastClick <= doubleClick)
        {
            isDoubleClick = true;
            charSt.Hilling(50, itemData);
            ResetDataItem();
        }
        else
        {
            isDoubleClick = false;
        }
        lastClickTime = Time.time;
        
    }
}
