using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharHPUI : MonoBehaviour
{
    private CharacterHP characterState;
    private Image imageHP;
    private TextMeshProUGUI textHP;
    private void Awake()
    {
        characterState = FindObjectOfType<CharacterHP>();
        imageHP = GetComponentInChildren<Image>();
        textHP = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        imageHP.fillAmount = characterState.GetCurrentHP() / 100;
        textHP.text = characterState.GetCurrentHP().ToString(); //ToString конвертирует число в текст
    }
}
