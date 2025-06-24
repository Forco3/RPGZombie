using UnityEngine;
using System;

public class AnimatorStateMutant : AnimStateBase
{   
    public override event Action onStateTakeDamage;
    public override event Action onStateAmimStartAttack;
    public override event Action onStateAmimEndAttack;

    //public event Action onStartTakeAttackAnim;
    //public event Action onEndTakeAttackAnim; 
    public override void StateEnter(AnimatorStateInfo stateInfo)
    {
        if (stateInfo.IsName("Enemy Attack") || stateInfo.IsName("Mutant Punch") || stateInfo.IsName("Jump Attack"))
        {
            onStateAmimStartAttack?.Invoke();
            isStartAttackAnim = true;
        }
        //if (stateInfo.IsName("Superhuman Choke Lift"))
        //{
        //    onStartTakeAttackAnim?.Invoke();
        //}
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
        if (stateInfo.IsName("Enemy Attack") || stateInfo.IsName("Mutant Punch") || stateInfo.IsName("Jump Attack"))
        {
            onStateAmimEndAttack?.Invoke();
            isStartAttackAnim = false;
        }
        //if (stateInfo.IsName("Superhuman Choke Lift"))
        //{
        //    onEndTakeAttackAnim?.Invoke();
        //}
    }
}
