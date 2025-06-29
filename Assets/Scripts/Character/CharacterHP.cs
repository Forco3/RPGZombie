using UnityEngine;

public class CharacterHP : MonoBehaviour
{
    private float currentHP = 100;
    

     
    private void OnEnable()
    {
        Time.timeScale = 1;
    }
 
    public void Hilling(float hill, Item dataItem)
    {
        if (dataItem.nameItem == "Medical")
        {
            currentHP += hill;
            Debug.Log(currentHP);
        }   
    }
    public void TakeDamage(float damage)
    {
        if(currentHP <= 0)
        {
            Debug.Log("Game Over");
            //turnOff MoveController
            //playAnim dead
            //waitTime 4 seconds for stopGame
            Time.timeScale = 0;
        }
        else
            currentHP -= damage;
    }
    public float GetCurrentHP()
    {
        return currentHP;
    }
}
