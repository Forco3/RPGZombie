using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MutantAttack : AttackBase
{
    public override event Action onDefaultAttackPlayAnim;
    public override event Action onPunchAttackPlayAnim;
    public override event Action onJumpAttackPlayAnim;
    public override event Action onTakeAttackPersonPlayAnim;
        
    public float damageMutant = 10;
    public float punchDamage = 15;
    public float jumpDamage = 25;

    //private Rigidbody rbPerson;
    //private Transform trPerson;
    //private Collider clPerson; 
    //public bool isTakePerson = false; 
    //public Transform trMutantHand;

    private void OnEnable()
    {
        animState.onStateAmimStartAttack += StartAnimAttack;
        animState.onStateAmimEndAttack += EndAnimAttack;
        //stateMutant.onStartTakeAttackAnim += OnStartTakeAttack;
        //stateMutant.onEndTakeAttackAnim += OnEndTakeAttack;
    }
    private void OnDisable()
    {
        animState.onStateAmimStartAttack -= StartAnimAttack;
        animState.onStateAmimEndAttack -= EndAnimAttack;
        //stateMutant.onStartTakeAttackAnim -= OnStartTakeAttack;
        //stateMutant.onEndTakeAttackAnim -= OnEndTakeAttack;
    }
    private void Update()
    {
        ThresholdAttack(move.distance);
        //if (isTakePerson)
        //{
        //    //AttackTakePerson();
        //    isTakePerson = false;
        //}
    }
    public override void ThresholdAttack(float distance)
    {
        if (distance <= move.minDistanceDefaultAttackTarget && distance > move.minDistancePunchAttackTarget && isAttackTarget && Time.time > timer)
        {
            timer = Time.time + 1.5f;
            damageMutant = defaultDamage;
            onDefaultAttackPlayAnim?.Invoke(); 
        }
        else if (distance < move.minDistancePunchAttackTarget && isAttackTarget && Time.time > timer)
        {
            timer = Time.time + 1.5f;
            damageMutant = punchDamage;
            onPunchAttackPlayAnim?.Invoke(); 
        }
        else if (distance < move.minDistanceJumpAttackTarget && isAttackTarget && Time.time > timer)
        {
            timer = Time.time + 1.5f;
            damageMutant = jumpDamage;
            onJumpAttackPlayAnim?.Invoke(); 
        }
    }
    public override void TakeDamage()
    {
        if (move.isMinDistanceDefaultAttack || move.isMinDistanceJumpAttack || move.isMinDistancePunchAttack)
        {
            target.TakeDamage(damageMutant);
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

    //private void AttackTakePerson()
    //{
    //    originalParent = trPerson.parent;
    //    trPerson.SetParent(trMutantHand);
    //    Debug.Log("TakePerson " + trPerson.name);
    //    onTakeAttackPerson?.Invoke();
    //}
    //private void OnStartTakeAttack()
    //{
    //    rbPerson.isKinematic = true;
    //    clPerson.enabled = false;
    //}
    //private void OnEndTakeAttack()
    //{
    //    trPerson.SetParent(originalParent);
    //    rbPerson.isKinematic = false;
    //    clPerson.enabled = true;
    //    isTakePerson = false;
    //}
}
