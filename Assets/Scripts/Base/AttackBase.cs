using System;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    public abstract event Action onDefaultAttackPlayAnim;
    public virtual event Action onPunchAttackPlayAnim;
    public virtual event Action onJumpAttackPlayAnim;
    public virtual event Action onTakeAttackPersonPlayAnim;
    public CharacterHP target { get; private set; }
    public AnimStateBase animState { get; private set; }
    public MoveBase move { get; private set; }
    public bool isMinDistanceTakeDamage { get; private set; } = false;

    public float minDistanceTakeDamage { get; private set; } = 1.5f;
    public bool isAttackTarget { get; set; } = true;

    public float damage;
    public float defaultDamage { get; private set; } = 10;

    public float timer { get; set; } = 0;

    private void Awake()
    {
        target = FindObjectOfType<CharacterHP>();
        animState = GetComponent<Animator>().GetBehaviour<AnimStateBase>();
        move = GetComponent<MoveBase>();
    }
    public virtual void ThresholdAttack(float distance)
    { 
    }
    public virtual void TakeDamage()
    { 
    }
    public virtual void StartAnimAttack()
    { 
    }
    public virtual void EndAnimAttack()
    { 
    }

}
