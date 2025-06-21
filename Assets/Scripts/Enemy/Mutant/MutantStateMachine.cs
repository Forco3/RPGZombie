using UnityEngine;
using System;

public class MutantStateMachine : StateMachineBehaviour
{
    public event Action onTakeDamage;
    public event Action onStartAttackAnim;
    public event Action onEndAttackAnim;
    public event Action onStartTakeAttackAnim;
    public event Action onEndTakeAttackAnim;

    private bool isStartAttackAnim;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Enemy Attack") || stateInfo.IsName("Mutant Punch") || stateInfo.IsName("Jump Attack"))
        {
            onStartAttackAnim?.Invoke();
            isStartAttackAnim = true;
        }
        if (stateInfo.IsName("Superhuman Choke Lift"))
        {
            onStartTakeAttackAnim?.Invoke();
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
        if (stateInfo.IsName("Enemy Attack") || stateInfo.IsName("Mutant Punch") || stateInfo.IsName("Jump Attack"))
        {
            onEndAttackAnim?.Invoke();
            isStartAttackAnim = false;
        }
        if (stateInfo.IsName("Superhuman Choke Lift"))
        {
            onEndTakeAttackAnim?.Invoke();
        }
    }
}
