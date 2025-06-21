using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class ForeachTest : MonoBehaviour
{ 
    private List<GameObject> myObjects = new List<GameObject>(12); 
    private List<Material> myMaterials = new List<Material>(12); 
    private void Start()
    {   
        // цикл работает как услованые конструкции и количество этираций зависит от размера списка
        for(int index = 0; index < myObjects.Count; index ++)
        { 
            // myObjects[index].gameObject.SetActive(true);

        }
        foreach (Material material in myMaterials)
        {
            // material.color = Color.red;
        }


        if (true)
            {   
                //sadasdada
                if (false)
                {
                    //adadawdadw
                }
            }
    } 
}
