using System; 
using UnityEngine;

public class EnemyAttack : AttackBase
{
    public override event Action onDefaultAttackPlayAnim;
    private void OnEnable()
    {
        animState.onStateAmimStartAttack += StartAnimAttack;
        animState.onStateAmimEndAttack += EndAnimAttack;
    }
    private void OnDisable()
    {
        animState.onStateAmimStartAttack -= StartAnimAttack;
        animState.onStateAmimEndAttack -= EndAnimAttack;
    }
    private void Update()
    {
        ThresholdAttack(move.distance);
    }
    public override void ThresholdAttack(float distance)
    {
        if (distance <= move.minDistanceDefaultAttackTarget && isAttackTarget && Time.time > timer)
        {
            timer = Time.time + 1.5f;
            damage = defaultDamage;
            onDefaultAttackPlayAnim?.Invoke();
        }
    }
    public override void TakeDamage()
    {
        if (move.isMinDistanceDefaultAttack)
        {
            target.TakeDamage(damage);
        }
        animState.onStateTakeDamage -= TakeDamage;
    }
    public override void StartAnimAttack()
    {
        isAttackTarget = false;
        animState.onStateTakeDamage += TakeDamage;
    }
    public override void EndAnimAttack()
    {
        isAttackTarget = true;
    }

}
