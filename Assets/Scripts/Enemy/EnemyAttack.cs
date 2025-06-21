using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public event Action onDefaultAttack;
    private protected CharacterState target { get; set; }
    public AnimatorStateEnemy stateEnemy {  get; private set; }
    public EnemyMove moveZ { get; private set; }
    public bool isMinDistanceTakeDamage { get; private set; } = false;

    public float minDistanceTakeDamage { get; private set; } = 1.5f;
    private protected bool isAttackTarget { get; set; } = true;

    public float damage;
    public float defaultDamage { get; private set; } = 10;

    public float timer { get; set; } = 0;

    private void Awake()
    {
        target = FindObjectOfType<CharacterState>();
        stateEnemy = GetComponent<Animator>().GetBehaviour<AnimatorStateEnemy>();
        moveZ = GetComponent<EnemyMove>();
    }
    private void OnEnable()
    {
        stateEnemy.onStartAttackAnim += StartAnimAttack;
        stateEnemy.onEndAttackAnim += EndAnimAttack;
    }
    private void OnDisable()
    {
        stateEnemy.onStartAttackAnim -= StartAnimAttack;
        stateEnemy.onEndAttackAnim -= EndAnimAttack;
    }
    private void Update()
    {
        ThresholdAttack(moveZ.distance);
    }
    public virtual void ThresholdAttack(float distance)
    {
        if (distance <= moveZ.minDistanceDefaultAttackTarget && isAttackTarget && Time.time > timer)
        {
            timer = Time.time + 1.5f;
            damage = defaultDamage;
            onDefaultAttack?.Invoke();
        }
    }
    public virtual void TakeDamage()
    {
        if (moveZ.isMinDistanceDefaultAttack)
        {
            target.TakeDamage(damage);
        }
        stateEnemy.onTakeDamage -= TakeDamage;
    }
    public virtual void StartAnimAttack()
    {
        isAttackTarget = false;
        stateEnemy.onTakeDamage += TakeDamage;
    }
    public virtual void EndAnimAttack()
    {
        isAttackTarget = true;
    }

}
