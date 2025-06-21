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
        Cursor.lockState = CursorLockMode.Locked; //блокируем курсор
    }
    private void LateUpdate()
    {
        ZoomCamera();
        RotateCamera();
    }
    private void ZoomCamera() // приближение/отдаление камеры
    {
        
    }
    private Vector3 InputCamera() // возвращает оси вращения, а именно тип данных Vector3 
    {
        horizontal += Input.GetAxis("Mouse X"); // эта функция возвращает дробное число от -1 до 1 по горизонтали
        vertical -= Input.GetAxis("Mouse Y"); // эта функция возвращает дробное число от -1 до 1 по вертикали
        vertical = Mathf.Clamp(vertical, -60, 60); // ограничиваем наклон камеры вверх/вниз в градусах

        return new Vector3(vertical, horizontal, 0); // переводим числа в оси вращения с типом данных Vector3
    }
    private void RotateCamera() // отвечает за поворот камеры относительно игрока
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