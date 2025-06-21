
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
        //cubeRigidbody = GetComponent<Rigidbody>(); // �� ����� ������ �� ������� ����� ������
        cubeRigidbody = transform.GetChild(0).GetComponent<Rigidbody>(); // �������� ��������� � ��������� ������
        //cubeRigidbody = transform.GetComponentInParent<Rigidbody>();
        //myMusor = transform.FindObjectOfType<Musor>(); // ����� ��������� �� ������� ������� � ���������
    }

    private void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Player")
        {
            cubeRigidbody.AddForce(Vector3.up * 8, ForceMode.Impulse);
        }
    }

}
