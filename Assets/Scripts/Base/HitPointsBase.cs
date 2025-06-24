using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class HitPointsBase : MonoBehaviour
{
    public abstract event Action onDeadPlayAudio;
    public MoveBase move { get; private set; }

    public Image imageHP { get; set; }
    public Rigidbody rb { get; private set; }
    public Collider coll { get; private set; }
    public Animator animator { get; private set; }
    [field: SerializeField] public float currentHP { get; set; } = 100;
    [field: Range(1, 10), SerializeField] public float ignoreDamage { get; set; } = 1;

    //field - модификатор для атрибута SerializeField, позволяющий отобразить переменную в инспекторе,
    //которая является свойством, т.е. {get; private set;}
  
    private void Awake()
    {
        move = GetComponent<MoveBase>();
        imageHP = GetComponentInChildren<Image>();
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        InactiveZombie(true);
        currentHP = 100;
        imageHP.fillAmount = currentHP / 100;
    }

    public abstract void OnTakeDamagePlayAudioDeadEvent();
    public void TakeDamageEnemy(float damage)
    {
        if (currentHP <= 0)
        {
            animator.SetTrigger("DeathTrigger");
            InactiveZombie(false);
            OnTakeDamagePlayAudioDeadEvent();
        }
        else
        {  
            currentHP -= damage / ignoreDamage;
        }
    }
    public void InactiveZombie(bool isActive)
    {
        rb.isKinematic = !isActive;
        coll.enabled = isActive;
        move.enabled = isActive;
    }
}
