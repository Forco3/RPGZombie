using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantAnimator : EnemyAnimator
{
    private MutantAttack attackMutant;
    private void Awake()
    {
        attackMutant = GetComponent<MutantAttack>();
    }
    private void OnEnable()
    {
        attackMutant.onAttack += DefaultAttackAnim;
        attackMutant.onPunchAttack += PunchAnimAttack;
        attackMutant.onJumpAttack += JumpAnimAttack;
        attackMutant.onTakeAttackPerson += TakePersonHand;
    }
    private void OnDisable()
    {
        attackMutant.onAttack -= DefaultAttackAnim;
        attackMutant.onPunchAttack -= PunchAnimAttack;
        attackMutant.onJumpAttack -= JumpAnimAttack;
        attackMutant.onTakeAttackPerson -= TakePersonHand;
    }
    private void TakePersonHand()
    {
        animZ.SetTrigger("TakePersonTrigger");
    }
}
