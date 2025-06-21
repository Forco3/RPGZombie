using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionData : MonoBehaviour
{
    private Rigidbody rb;
    private Transform transCube;
    private RigigdBodyCastom rbC;

    private float number;
    private float number2;

    private void Start()
    {
        rbC.AddForceC(transCube.position); // здесь мы передали входящи Аргумент  
       
        number2 = Random.Range(45, 100);

        float sum = rbC.Calculate(number, number2);

        transCube.Translate(Vector3.up * sum * Time.deltaTime);
    }  
}
