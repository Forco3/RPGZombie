
using UnityEngine;

public class ConstructIf : MonoBehaviour
{
    private Transform trPlatform;
    public float movespeed = 3f;
    
    public float minHeight = 1;
    public float maxHeight = 10;


    private bool IsMoveUP = true;
    private bool IsMoveDown = false;
    private void Start()
    {   
        trPlatform = GetComponent<Transform>(); 
        trPlatform.position = new Vector3(trPlatform.position.x, 1, trPlatform.position.z);
    }

    private void Update()
    {
        if (IsMoveDown)
        {
            MoveDown();
            Debug.Log("moveDown");
        } 
        if (IsMoveUP)
        {
            MoveUp();
            Debug.Log("moveUp");
        } 
    }

    public void MoveDown()
    {   
        if(minHeight < trPlatform.position.y)
        {
            trPlatform.position += Vector3.down * movespeed * Time.deltaTime;
            IsMoveDown = true;
            IsMoveUP = false;
        }
        else 
        {
            IsMoveDown = false;
            IsMoveUP = true;
        }
    }
    public void MoveUp()
    { 
        if (maxHeight > trPlatform.position.y)
        {
            trPlatform.position += Vector3.up * movespeed * Time.deltaTime;
            IsMoveUP = true;
            IsMoveDown = false;
        }
        else
        {
            IsMoveUP = false;
            IsMoveDown = true;
        }
    }
}
