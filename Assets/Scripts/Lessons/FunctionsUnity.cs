using UnityEngine;

public class FunctionsUnity : MonoBehaviour
{
    public GameObject myCube;
    private void Awake()
    {
        // ������ ������� ��� ������ ���� 1 ��� �� ���� �����
        
    }
    private void OnEnable()
    {
        // ������ ������� ��� ������ ���� 1 ��� � ������ ��� ��� ��������� ��� ��������� ������� 
        // ������
        // slotImage.enabled = true; ���/���� ���������
        // gameObject.SetActive(false); ���/���� ��� ������
    }
    private void OnDisable()
    {
        // ������ ������� ��� ���������� ���� 1 ��� � ������ ��� ��� ���� ��� ����������� ������� 
        // ������
        // slotImage.enabled = true/false; ���/���� ���������
        // gameObject.SetActive(true/false); ���/���� ��� ������
    }
    private void Start()
    {
        // ������ ������� ��� ������ ���� 1 ��� �� ���� �����
         
    }
     
    private void Update()
    {
        // ����������� ��� ������ � ����� ��� �� ��������� ������ 
    }
    private void LateUpdate()
    {
        // ��� �������� �������� �������� ������
    }
    private void FixedUpdate()
    {
        // ��� ������� ������� ������ �������� �������� ��� ����������
    }

    private void OnCollisionEnter(Collision collision) 
    {
        // ����������� ���� ��� ��� ������ ������������ ������� �������
        //, �� ����� �� ������� ����� ���� rigidbody
         
    }
    private void OnCollisionStay(Collision collision)
    {
        // ���������� ������ ��� ���� collision ������� ������������� 
        //, �� ����� �� ������� ����� ���� rigidbody

    }
    private void OnCollisionExit(Collision collision)
    {
        // ����������� ���� ��� ��� ������ ���������� ������� �������
        //, �� ����� �� ������� ����� ���� rigidbody

    }
    private void OnTriggerEnter(Collider coll)
    {
        // ����������� ���� ��� ��� ������ ������������ ������� ������� � ���������� ������� trigger
        //, �� ����� �� ������� ����� ���� rigidbody
    }
    private void OnTriggerStay(Collider collision)
    {
        // ���������� ������ ��� ���� collision ������� ������������� � ���������� ������� trigger
        //, �� ����� �� ������� ����� ���� rigidbody
    }
    private void OnTriggerExit(Collider collision) 
    {
        // ����������� ���� ��� ��� ������ ���������� ������� ������� � ���������� ������� trigger
        //, �� ����� �� ������� ����� ���� rigidbody

    }

    // ����������� ��� �������������� ������� ����� � �������� 
    // ��� ������� �������� � 2D/3D ��������� ��� ������� �� ��� ����������
    // ������ ������ ������ �� ����� �������
    // �� �������� �� �������, � �������� ���� ���. ������ � ����������� Rigidbody
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
