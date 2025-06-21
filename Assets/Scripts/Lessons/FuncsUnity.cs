 
using UnityEngine;

public class FuncsUnity : MonoBehaviour
{
    public Rigidbody rbCube;

    private float jumpForce = 10f;
    public void Start()
    {
        rbCube.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
