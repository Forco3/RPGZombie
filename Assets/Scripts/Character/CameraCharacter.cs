using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCharacter : MonoBehaviour
{
    public Transform lookPointCameraForRaycast;
    private Transform transCamera;
    private Vector3 offset;
    public float minAngle = 90;
    public float maxAngle;
    private float horizontal;
    private float vertical;
    private void Awake()
    {
        transCamera = GetComponent<Transform>();
    }
    private void Start()
    {
        offset = transCamera.position - lookPointCameraForRaycast.position;
        Cursor.lockState = CursorLockMode.Locked; //��������� ������
    }
    private void LateUpdate()
    {
        ZoomCamera();
        RotateCamera();
    }
    private void ZoomCamera() // �����������/��������� ������
    {
        
    }
    private Vector3 InputCamera() // ���������� ��� ��������, � ������ ��� ������ Vector3 
    {
        horizontal += Input.GetAxis("Mouse X"); // ��� ������� ���������� ������� ����� �� -1 �� 1 �� �����������
        vertical -= Input.GetAxis("Mouse Y"); // ��� ������� ���������� ������� ����� �� -1 �� 1 �� ���������
        vertical = Mathf.Clamp(vertical, -60, 60); // ������������ ������ ������ �����/���� � ��������

        return new Vector3(vertical, horizontal, 0); // ��������� ����� � ��� �������� � ����� ������ Vector3
    }
    private void RotateCamera() // �������� �� ������� ������ ������������ ������
    {
        transform.localEulerAngles = InputCamera();
        transCamera.position = transCamera.localRotation * offset + lookPointCameraForRaycast.position;
    }
    public bool CheckAngleRotateCamera()
    {
        Vector3 cameraForward = Vector3.ProjectOnPlane(transCamera.forward, Vector3.up).normalized;
        Vector3 characterForward = Vector3.ProjectOnPlane(lookPointCameraForRaycast.forward, Vector3.up).normalized;
        float currentAngle = Vector3.SignedAngle(cameraForward, characterForward, Vector3.up);
        Debug.Log(Mathf.Abs(currentAngle));
        return Mathf.Abs(currentAngle) > minAngle ? true : false;
    }
}