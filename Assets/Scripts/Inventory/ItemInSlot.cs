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
    private RectTransform rectTransform; //RectTransform- ��������� ��� UI 2d ��������
    private Transform originalParent; //��������� Transform � �������� (Slot)
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
        imageItem.sprite = itemData.spriteItem; //���������� ������ (�������� ������������ ��������) � ��������� Image
        textItem.text = itemData.nameItem;
    }
    public void ResetDataItem()
    {
        itemData = null;
        imageItem.sprite = null;
        textItem.text = "";
    }
    public void OnBeginDrag(PointerEventData eventData) //PointerEventData- �����, ���������� �� ������ ����� (������������ ������� ������� �����, ��� ��������� � �����)
    {
        canvasGroup.blocksRaycasts = false; //��������� ���������� ����, ����� �� �������������� ����������� �����
        canvasGroup.alpha = 0.5f; //������������� ������������ ������� �� ������� (� ������ ������ ���������)
        originalParent = transform.parent; //�������� ��������� Transform �������� ������� Slot
        rectTransform.SetParent(canvas.transform); //������������� ������ �������� Canvas
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; //����� �������� ������� ����� �� ������ UI ������ //anchoredPosition- ������� � 2d (Vector2) ������������
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; 
        canvasGroup.alpha = 1; //������������� ������������ ������� �� ������� (� ������ ������ ����������� ������� �� 1)
        rectTransform.SetParent(originalParent); //���������� �������� ��� ������� �� �������
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
