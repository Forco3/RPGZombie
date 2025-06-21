 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;

public class ListForeach: MonoBehaviour 
{ 
    public List<Image> gameObjects = new List<Image>();
    private Image image;
    private void Awake()
    {
        gameObjects.AddRange(FindObjectsOfType<Image>());
    }

    private void Start()
    {
        for(short index = 0; index < gameObjects.Count; index++)
        {
            if(index % 2 == 0)
            {
                gameObjects[index].color = Color.red;
            }
            else
            {
                gameObjects[index].color = Color.green;
            }
            gameObjects.Add(image);
            gameObjects.Remove(image);
            bool iHas = gameObjects.Contains(image);
            int  amount =  gameObjects.Count;
        }
    } 
}
