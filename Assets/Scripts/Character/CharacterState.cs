using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    private float currentHP = 100;
    public bool isReadyForBattle { get; private set; } //свойства должны быть публичными

    private void Update()
    {
        
    }
    private void OnEnable()
    {
        Time.timeScale = 1;
    }
    public void SetStateReadyForBattle(bool isReadyForBattle)
    {
        this.isReadyForBattle = isReadyForBattle;
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
