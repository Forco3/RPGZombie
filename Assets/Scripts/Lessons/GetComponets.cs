
using UnityEngine;

public class GetComponets : MonoBehaviour
{
    private Collider cubeCollider;
    private Transform parentTransform;
    private Rigidbody cubeRigidbody;
    private Musor myMusor;

    private void Awake()
    {
        cubeCollider = GetComponent<Collider>();
        parentTransform = GetComponent<Transform>();
        //cubeRigidbody = GetComponent<Rigidbody>(); // на самом обекте на котором висит скрипт
        cubeRigidbody = transform.GetChild(0).GetComponent<Rigidbody>(); // получаем компонент у дочернего обекта
        //cubeRigidbody = transform.GetComponentInParent<Rigidbody>();
        //myMusor = transform.FindObjectOfType<Musor>(); // найти компонент на игровом объекте в ииерархии
    }

    private void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Player")
        {
            cubeRigidbody.AddForce(Vector3.up * 8, ForceMode.Impulse);
        }
    }

}
