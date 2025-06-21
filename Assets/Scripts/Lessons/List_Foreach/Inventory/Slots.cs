
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// 1 Подключить интерфейс - например IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler  
// 2 Подключить библиотеку - using UnityEngine.EventSystems;
// 3 Реализовать функции интерфейса
// 4 Должен быть UI игровой объект - EventSystems
// 5 На камере должен быть компонент PhysicsRayCast, если игра 2D, то PhysicsRayCast2D
// 6 Не забыть повесить скрипт на объект

// Если надо взаимодействовать с 3D объектами (например-куб), то на объекте должен быть коллайдер
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
            // slotImage.enabled = true; вкл/выкл компонент
            // gameObject.SetActive(false); вкл/выкл сам объект
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
