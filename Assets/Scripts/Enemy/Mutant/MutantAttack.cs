using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MutantAttack : EnemyAttack
{
    public event Action onAttack;
    public event Action onPunchAttack;
    public event Action onJumpAttack;
    public event Action onTakeAttackPerson;

    private Transform originalParent;

    private MutantMove moveM;
    private MutantStateMachine stateMutant;

    private Rigidbody rbPerson;
    private Transform trPerson;
    private Collider clPerson;

    public bool isTakePerson = false;

    public Transform trMutantHand;

    public float damageMutant = 10;
    public float punchDamage = 15;
    public float jumpDamage = 25;

    private void Awake()
    {
        moveM = GetComponent<MutantMove>();
        target = FindObjectOfType<CharacterState>();
        trPerson = target.transform;
        rbPerson = target.GetComponent<Rigidbody>();
        clPerson = target.GetComponent<Collider>();
        stateMutant = GetComponent<Animator>().GetBehaviour<MutantStateMachine>();
    }

    private void OnEnable()
    {
        stateMutant.onStartAttackAnim += StartAnimAttack;
        stateMutant.onEndAttackAnim += EndAnimAttack;
        stateMutant.onStartTakeAttackAnim += OnStartTakeAttack;
        stateMutant.onEndTakeAttackAnim += OnEndTakeAttack;
    }
    private void OnDisable()
    {
        stateMutant.onStartAttackAnim -= StartAnimAttack;
        stateMutant.onEndAttackAnim -= EndAnimAttack;
        stateMutant.onStartTakeAttackAnim -= OnStartTakeAttack;
        stateMutant.onEndTakeAttackAnim -= OnEndTakeAttack;
    }
    private void Update()
    {
        ThresholdAttack(moveM.distance);
        if (isTakePerson)
        {
            AttackTakePerson();
            isTakePerson = false;
        }
    }
    public override void ThresholdAttack(float distance)
    {
        if (distance <= moveM.minDistanceDefaultAttackTarget && distance > moveM.minDistancePunchAttackTarget && isAttackTarget && Time.time > timer)
        {
            timer = Time.time + 1.5f;
            damageMutant = defaultDamage;
            onAttack?.Invoke();
            Debug.Log("Default");
        }
        else if (distance < moveM.minDistancePunchAttackTarget && isAttackTarget && Time.time > timer)
        {
            timer = Time.time + 1.5f;
            damageMutant = punchDamage;
            onPunchAttack?.Invoke();
            Debug.Log("Punch");
        }
        else if (distance < moveM.minDistanceJumpAttackTarget && isAttackTarget && Time.time > timer)
        {
            timer = Time.time + 1.5f;
            damageMutant = jumpDamage;
            onJumpAttack?.Invoke();
            Debug.Log("Jump");
        }
    }
    private void AttackTakePerson()
    {
        originalParent = trPerson.parent;
        trPerson.SetParent(trMutantHand);
        Debug.Log("TakePerson " + trPerson.name);
        onTakeAttackPerson?.Invoke();
    }
    private void OnStartTakeAttack()
    {
        rbPerson.isKinematic = true;
        clPerson.enabled = false;
    }
    private void OnEndTakeAttack()
    {
        trPerson.SetParent(originalParent);
        rbPerson.isKinematic = false;
        clPerson.enabled = true;
        isTakePerson = false;
    }
    public override void TakeDamage()
    {
        if (moveM.isMinDistanceDefaultAttack || moveM.isMinDistanceJumpAttack || moveM.isMinDistancePunchAttack)
        {
            target.TakeDamage(damageMutant);
        }
        stateMutant.onTakeDamage -= TakeDamage;
    }
    public override void StartAnimAttack()
    {
        isAttackTarget = false;
        stateMutant.onTakeDamage += TakeDamage;
    }
    public override void EndAnimAttack()
    {
        isAttackTarget = true;
    }
}
