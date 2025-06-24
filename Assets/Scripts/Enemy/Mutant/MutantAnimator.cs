public class MutantAnimator : AnimBase
{  
    private void OnEnable()
    {
        move.onScreamPlayAnim += ScrimerAnim;
        attack.onDefaultAttackPlayAnim += DefaultAttackAnim;
        attack.onPunchAttackPlayAnim += PunchAnimAttack;
        attack.onJumpAttackPlayAnim += JumpAnimAttack;
        //attack.onTakeAttackPersonPlayAnim += TakePersonHand;
    }
    private void OnDisable()
    {
        move.onScreamPlayAnim -= ScrimerAnim;
        attack.onDefaultAttackPlayAnim -= DefaultAttackAnim;
        attack.onPunchAttackPlayAnim -= PunchAnimAttack;
        attack.onJumpAttackPlayAnim -= JumpAnimAttack;
        //attack.onTakeAttackPersonPlayAnim -= TakePersonHand;
    }
    //private void TakePersonHand()
    //{
    //    animator.SetTrigger("TakePersonTrigger");
    //}
}
