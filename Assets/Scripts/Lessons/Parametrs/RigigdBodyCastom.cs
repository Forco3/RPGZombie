
using UnityEngine;

public class RigigdBodyCastom : MonoBehaviour
{    
     public void AddForceC(Vector3 position) // один  Параметр вектор три
     {
        position += Vector3.down * 10 * Time.deltaTime;
     }

    public float Calculate(float A, float B)
    {
        float C = A + B;
        return C; //  
    }
}
