using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorStateEnemy : StateMachineBehaviour
{
    public event Action onTakeDamage;
    public event Action onStartAttackAnim;
    public event Action onEndAttackAnim;

    private bool isStartAttackAnim;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Enemy Attack"))
        {
            onStartAttackAnim?.Invoke();
            isStartAttackAnim = true;
        }
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 0.65f && isStartAttackAnim)
        {
            onTakeDamage?.Invoke();
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Enemy Attack"))
        {
            onEndAttackAnim?.Invoke();
            isStartAttackAnim = false;
        }
    }
}
