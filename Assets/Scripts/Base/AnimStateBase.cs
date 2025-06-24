using System;
using UnityEngine;

public abstract class AnimStateBase : StateMachineBehaviour
{
    public abstract event Action onStateTakeDamage;
    public abstract event Action onStateAmimStartAttack;
    public abstract event Action onStateAmimEndAttack;

    public bool isStartAttackAnim;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateEnter(stateInfo);
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateUpdate(stateInfo);
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateExit(stateInfo);
    }
    public abstract void StateEnter(AnimatorStateInfo stateInfo);
    public abstract void StateUpdate(AnimatorStateInfo stateInfo);
    public abstract void StateExit(AnimatorStateInfo stateInfo);
}
