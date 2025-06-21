using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChar : MonoBehaviour
{
    private CameraCharacter cameraChar;
    private CharacterAnimator characterAnim;

    private Rigidbody rbPerson;

    private Vector3 newDirection;
    private Vector3 forward;

    public float speedRun = 5;
    public float speedWalk = 3;
    public float speedSprint = 7;
    public float speedRotate = 45;
    public float jumpForce = 3;
    public float sprint = 10;
    public float currentSpeed;
    private bool isTerrain;
    private void Awake()
    {
        rbPerson = GetComponent<Rigidbody>();
        cameraChar = FindObjectOfType<CameraCharacter>();
        characterAnim = GetComponent<CharacterAnimator>();
    }
    private void FixedUpdate()
    {
        Vector3 inputAxis = InputAxis();
        SetDirrection(inputAxis);
        characterAnim.MoveAnim(inputAxis);
        Moving(newDirection);
        Rotating(cameraChar);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            characterAnim.CharacterCrouchAnim();
        }
        Jumping();
        
    }

    private Vector3 InputAxis()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        return new Vector3 (x, 0, z);  
    }
    private void SetDirrection(Vector3 inputAxis) //��������� �����������, � ������� ������ ��������� ������
    {
        forward = Vector3.ProjectOnPlane(cameraChar.transform.forward, Vector3.up); //��������� ����������� �������� ����� ������������ ������
        Vector3 right = Vector3.ProjectOnPlane(cameraChar.transform.right, Vector3.up); //��������� ����������� �������� ������ ������������ ������
        newDirection = (inputAxis.z * forward) + (inputAxis.x * right); //��������� ����������� �������� � �������� ��������
    }
    private void Rotating(CameraCharacter camChar)
    {
        Quaternion rotate = Quaternion.LookRotation(forward, Vector3.up); //������ �������� ��� ��������� �� ��������� ��������� ����
        Quaternion newRotate = Quaternion.Lerp(rbPerson.rotation, rotate, Time.fixedDeltaTime * speedRotate);
        rbPerson.MoveRotation(newRotate);
    }
    private void Moving(Vector3 vector3)
    {
        currentSpeed = Input.GetKey(KeyCode.LeftAlt) ? speedWalk : Input.GetKey(KeyCode.LeftShift) ? speedSprint : speedRun;
        rbPerson.MovePosition(rbPerson.position + vector3 * currentSpeed * Time.deltaTime);
        
    }
    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTerrain) 
        {
            rbPerson.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            characterAnim.JumpAnim(true); 
        }
        else characterAnim.JumpAnim(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain") 
        {
            isTerrain = true;
        }
    }
    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.tag == "Terrain") 
        {
            isTerrain = false;
        }
    }
}

