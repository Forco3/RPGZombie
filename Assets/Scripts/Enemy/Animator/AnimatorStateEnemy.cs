using System;
using UnityEngine;

public class AnimatorStateEnemy : AnimStateBase
{
    public override event Action onStateTakeDamage;
    public override event Action onStateAmimStartAttack;
    public override event Action onStateAmimEndAttack;
      
    public override void StateEnter(AnimatorStateInfo stateInfo)
    {

        if (stateInfo.IsName("Enemy Attack"))
        {
            onStateAmimStartAttack?.Invoke();
            isStartAttackAnim = true;
        }
    }

    public override void StateUpdate(AnimatorStateInfo stateInfo)
    {
        if (stateInfo.normalizedTime >= 0.65f && isStartAttackAnim)
        {
            onStateTakeDamage?.Invoke();
        }
    }

    public override void StateExit(AnimatorStateInfo stateInfo)
    {
        if (stateInfo.IsName("Enemy Attack"))
        {
            onStateAmimEndAttack?.Invoke();
            isStartAttackAnim = false;
        }
    }
}
