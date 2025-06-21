
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// 1 ���������� ��������� - �������� IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler  
// 2 ���������� ���������� - using UnityEngine.EventSystems;
// 3 ����������� ������� ����������
// 4 ������ ���� UI ������� ������ - EventSystems
// 5 �� ������ ������ ���� ��������� PhysicsRayCast, ���� ���� 2D, �� PhysicsRayCast2D
// 6 �� ������ �������� ������ �� ������

// ���� ���� ����������������� � 3D ��������� (��������-���), �� �� ������� ������ ���� ���������
public class Slots : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler,IDragHandler, IEndDragHandler
{
    private Image slotImage;
    private RectTransform transSlot;
    private Canvas canvasUI;
    private Transform transUI;
    private void Awake()
    {
        slotImage = GetComponent<Image>();
        transSlot = GetComponent<RectTransform>();
        canvasUI = transform.GetComponentInParent<Canvas>();
       
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("click");
            // slotImage.enabled = true; ���/���� ���������
            // gameObject.SetActive(false); ���/���� ��� ������
            slotImage.color = Color.red;
        }
        else if(eventData.button == PointerEventData.InputButton.Right)
        {
            slotImage.color = Color.blue;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transSlot.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transSlot.localScale = new Vector3(1, 1, 1);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transSlot.SetAsLastSibling();
        transUI = transform.parent;
        transSlot.SetParent(canvasUI.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transSlot.anchoredPosition += eventData.delta/canvasUI.scaleFactor;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transSlot.SetParent(transUI);
    }
}
