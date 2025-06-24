using UnityEngine;

public class EnemyAnimator : AnimBase
{  
    private void OnEnable()
    {
        move.onScreamPlayAnim += ScrimerAnim;
        attack.onDefaultAttackPlayAnim += DefaultAttackAnim;
    }
    private void OnDisable()
    {
        move.onScreamPlayAnim -= ScrimerAnim;
        attack.onDefaultAttackPlayAnim -= DefaultAttackAnim;
    } 
}
