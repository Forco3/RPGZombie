using UnityEngine;

public class FunctionsUnity : MonoBehaviour
{
    public GameObject myCube;
    private void Awake()
    {
        // запуск функции при старте игры 1 раз за весь сеанс
        
    }
    private void OnEnable()
    {
        // запуск функции при старте игры 1 раз и каждый раз при включении или активации объекта 
        // Пример
        // slotImage.enabled = true; вкл/выкл компонент
        // gameObject.SetActive(false); вкл/выкл сам объект
    }
    private void OnDisable()
    {
        // запуск функции при выключении игры 1 раз и каждый раз при выкл или деактивации объекта 
        // Пример
        // slotImage.enabled = true/false; вкл/выкл компонент
        // gameObject.SetActive(true/false); вкл/выкл сам объект
    }
    private void Start()
    {
        // запуск функции при старте игры 1 раз за весь сеанс
         
    }
     
    private void Update()
    {
        // запускается при старте и много раз до окончания сеанса 
    }
    private void LateUpdate()
    {
        // для плавного просчета движения камеры
    }
    private void FixedUpdate()
    {
        // для точного прочета физики например колайдер или риджедбоди
    }

    private void OnCollisionEnter(Collision collision) 
    {
        // запускается один раз при каждом столкновении колизий объекта
        //, на одном из обектов дожен быть rigidbody
         
    }
    private void OnCollisionStay(Collision collision)
    {
        // заускается каждый раз пока collision объекта соприкасаются 
        //, на одном из обектов дожен быть rigidbody

    }
    private void OnCollisionExit(Collision collision)
    {
        // запускается один раз при каждом завершении колизий объекта
        //, на одном из обектов дожен быть rigidbody

    }
    private void OnTriggerEnter(Collider coll)
    {
        // запускается один раз при каждом столкновении колизий объекта и включенной галочки trigger
        //, на одном из обектов дожен быть rigidbody
    }
    private void OnTriggerStay(Collider collision)
    {
        // заускается каждый раз пока collision объекта соприкасаются и включенной галочки trigger
        //, на одном из обектов дожен быть rigidbody
    }
    private void OnTriggerExit(Collider collision) 
    {
        // запускается один раз при каждом завершении колизий объекта и включенной галочки trigger
        //, на одном из обектов дожен быть rigidbody

    }

    // Срабатывают при взаимодействии курсора мышки с объектом 
    // Эти функции работают с 2D/3D объектами при наличии на них коллайдера
    // Скрипт должен висеть на самом объекте
    // Не работает на объекте, у которого есть род. объект с компонентом Rigidbody
    private void OnMouseEnter()
    {
        Debug.Log("enter");
    }
    private void OnMouseExit()
    {
        Debug.Log("exit");
    } 
    private void OnMouseDown() 
    {
        Debug.Log("Down");
    } 
    private void OnMouseUp()
    {
        Debug.Log("Up");

    } 
}
