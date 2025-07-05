using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAnimator : StateMachineBehaviour
{
    private CharacterState charState;
    private void Awake()
    {
        charState = FindObjectOfType<CharacterState>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (layerIndex == 1)
        {
            StartAnimEquip(stateInfo, true);
            StartAnimUnEquip(stateInfo, true);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (layerIndex == 1)
        {
            StartAnimEquip(stateInfo, false);
            StartAnimUnEquip(stateInfo, false);
        }
    }
    public void StartAnimEquip(AnimatorStateInfo stateInfo, bool isStart)
    {
        if (stateInfo.IsName("Rifle Pull Out"))
        {
            charState.SetEquipingWeaponAnimationState(isStart);
        }
    }
    public void StartAnimUnEquip(AnimatorStateInfo stateInfo, bool isStart)
    {
        if (stateInfo.IsName("Rifle Put Away"))
        {
            charState.SetEquipingWeaponAnimationState(isStart);
        }
    }
}
