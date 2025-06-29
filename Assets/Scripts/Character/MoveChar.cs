using UnityEngine;

public class MoveChar : MonoBehaviour
{
    private StateCharacter state;
    private CameraCharacter cameraChar; 

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
    private void Awake()
    {
        state = GetComponent<StateCharacter>();
        rbPerson = GetComponent<Rigidbody>();
        cameraChar = FindObjectOfType<CameraCharacter>(); 
    }
    private void FixedUpdate()
    { 
        SetDirrection(state.inputAxis); 
        Moving(newDirection);
        Rotating(cameraChar);
    }
    private void Update()
    { 
        Jumping(state.isKeyDownJump); 
    }

   
    private void SetDirrection(Vector3 inputAxis) //указываем направление, в котором должен двигаться объект
    {
        forward = Vector3.ProjectOnPlane(cameraChar.transform.forward, Vector3.up); //указываем направление движения вперёд относительно камеры
        Vector3 right = Vector3.ProjectOnPlane(cameraChar.transform.right, Vector3.up); //указываем направление движения вправо относительно камеры
        newDirection = (inputAxis.z * forward) + (inputAxis.x * right); //смешиваем направление движения с нажатыми кнопками
    }
    private void Rotating(CameraCharacter camChar)
    {
        Quaternion rotate = Quaternion.LookRotation(forward, Vector3.up); //создаём вращение для персонажа по указанным локальным осям
        Quaternion newRotate = Quaternion.Lerp(rbPerson.rotation, rotate, Time.fixedDeltaTime * speedRotate);
        rbPerson.MoveRotation(newRotate);
    }
    private void Moving(Vector3 vector3)
    {
        currentSpeed = Input.GetKey(KeyCode.LeftAlt) ? speedWalk : Input.GetKey(KeyCode.LeftShift) ? speedSprint : speedRun;
        rbPerson.MovePosition(rbPerson.position + vector3 * currentSpeed * Time.deltaTime);
        
    }
    private void Jumping(bool isKeyDownJump)
    {
        if (isKeyDownJump && state.isCollisitonTerrain) 
        {
            rbPerson.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        } 
    }
    private void OnCollisionEnter(Collision collision)
    {
        state.SetStateCollisionTerrain(true);
    }
    private void OnCollisionExit(Collision collision) 
    {
        state.SetStateCollisionTerrain(false);
    }
}

