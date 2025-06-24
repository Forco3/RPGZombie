using System;
using System.Collections;
using UnityEngine;


//это атрибут, который гарантирует, что данный компонент будет добавлен на объект, на котором висит этот скрипт
[RequireComponent(typeof(Rigidbody))]
public abstract class MoveBase : MonoBehaviour
{
    public abstract event Action onScreamPlayAnim;
    public abstract event Action onScreamerPlayAudio;

    public CharacterHP targetChar { get; private set; }
    public Transform transChar { get; private set; }

    public AnimStateBase animState { get; private set; }
    public Transform tr { get; private set; }
    public Rigidbody rb { get; private set; }
    public Animator animator { get; private set; }
    public AnimBase anim { get; private set; }

    public float speedFollow { get; private set; } = 5;
    public float speedRotate { get; private set; } = 2;

    public float distance;
    public float minDistanceFollowTarget { get; private set; } = 15;
    public float minDistanceLookTarget { get; private set; } = 25;

    public float minDistanceDefaultAttackTarget { get; private set; } = 1;
    public float minDistancePunchAttackTarget { get; private set; } = 2;
    public float minDistanceJumpAttackTarget { get; private set; } = 4;

    
    [Header("State - Idle, Screamer begin true")]

    public bool isIdle = true;
    public bool isScreamer = true;
    public bool isLookTarget = false;
    public bool isFollowTarget = false;

    public bool isMinDistanceDefaultAttack = false;
    public bool isMinDistancePunchAttack = false;
    public bool isMinDistanceJumpAttack = false;


    private void Awake()
    {
        targetChar = FindObjectOfType<CharacterHP>();
        transChar = FindObjectOfType<MoveChar>().transform;

        animator = GetComponent<Animator>();
        animState = animator.GetBehaviour<AnimStateBase>(); 
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<AnimBase>();
    }
    private void OnEnable()
    {
        isScreamer = true;
    }
    private void Update()
    {
        isFollowTarget = IsMinDistance(minDistanceFollowTarget);
        isLookTarget = IsMinDistance(minDistanceLookTarget);
        isMinDistanceDefaultAttack = IsMinDistance(minDistanceDefaultAttackTarget);
        isMinDistancePunchAttack = IsMinDistance(minDistancePunchAttackTarget);
        isMinDistanceJumpAttack = IsMinDistance(minDistanceJumpAttackTarget);
        if (isScreamer && isLookTarget)
        {
            StartCoroutine(ScreamWaitTime());
        }
    }
    public abstract void OnScreamPlayAnimEvent();
    public abstract void OnScreamPlayAudioEvent();
    protected IEnumerator ScreamWaitTime()
    {
        OnScreamPlayAnimEvent();
        OnScreamPlayAudioEvent();
        isScreamer = false;
        isIdle = true;
        yield return new WaitForSeconds(2.3f);
        isIdle = false;
    }


    protected void FollowTarget()
    {
        if (isFollowTarget && !isScreamer && !isIdle)
        {
            anim.MoveAnim(1);
            Move(transform.forward);
        }
    }
    protected bool IsMinDistance(float minDistance)
    {
        distance = Vector3.Distance(tr.position, transChar.position);
        if (distance <= minDistance)
            return true;
        else return false;
    }
    protected void LookTarget()
    {
        if (isFollowTarget && IsMinDistance(minDistanceLookTarget))
        {
            Vector3 direction = (transChar.position - tr.position).normalized;
            Quaternion rotate = Quaternion.LookRotation(direction, Vector3.up);
            Rotate(rotate);
        }
    }
    public void Move(Vector3 position)
    {
        rb.MovePosition(rb.position + position * speedFollow * Time.fixedDeltaTime);
    }
    public void Rotate(Quaternion direction)
    {
        Quaternion smoothRotate = Quaternion.Slerp(tr.rotation, direction, Time.fixedDeltaTime * speedRotate);
        rb.MoveRotation(smoothRotate);
    }
}
