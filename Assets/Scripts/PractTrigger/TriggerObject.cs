
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public GameObject cube;
    public Material materialCube;
    public Rigidbody rbCube;
    public Transform trCube;

    public float jumpForce = 5f;
    public float moveDistance = 3f;
    public float speedRotate = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cube.SetActive(true);
            materialCube.color = Color.blue;
            JumpCube();
           
   
            }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Moving();
            RotateCube();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            materialCube.color = Color.white;
            
        }
    }
    
   private void JumpCube()
    {
        rbCube.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    private void Moving()
    {
        trCube.Translate(Vector3.forward * moveDistance * Time.deltaTime);
    }
    private void IncreaseCubeScale()
    {
        float x = 20.5f;
        float y = 10.5f;
        float z = 15.5f;
        trCube.localScale = new Vector3(x, y, z);
    }

    private void IncreaseCubeScale2()
    {
        float x = 1f;
        float y = 1f;
        float z = 1f;
        trCube.localScale = new Vector3(x, y, z);
    }
    private  void RotateCube()
    {
        Vector3 angle = new Vector3(30, 30, 30); 
        trCube.rotation = Quaternion.Euler(angle * speedRotate * Time.deltaTime);
    }
}
