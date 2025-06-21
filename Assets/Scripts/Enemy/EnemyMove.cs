using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //это атрибут, который гарантирует, что данный компонент будет добавлен на объект, на котором висит этот скрипт
public class EnemyMove : MonoBehaviour
{
    private CharacterState state;
    private AnimatorStateEnemy stateEnemy;

    private Transform transChar;
    private Transform transEnemy;
    private Rigidbody rigEnemy;

    private Animator animatorZ;

    private EnemyAnimator animZ;
    public float speedFollow = 5;
    public float speedRotate = 2;

    public float distance;
    public float minDistanceFollowTarget = 15;
    public float minDistanceLookTarget = 25;
    public float minDistanceDefaultAttackTarget = 1;
    [Header("State - Idle, Screamer begin true")]
    public bool isIdle = true;
    public bool isScreamer = true;
    public bool isLookTarget = false;
    public bool isFollowTarget = false;
    public bool isMinDistanceDefaultAttack = false;
 
    public event Action onScream;
    public event Action onPlayAudioZombieScreamer;
    private void Awake()
    {
        state = FindObjectOfType<CharacterState>();
        animatorZ = GetComponent<Animator>();
        stateEnemy = animatorZ.GetBehaviour<AnimatorStateEnemy>();
        transChar = FindObjectOfType<MoveChar>().transform;
        transEnemy = GetComponent<Transform>();
        rigEnemy = GetComponent<Rigidbody>();
        animZ = GetComponent<EnemyAnimator>();
    }
    private void OnEnable()
    {
        isScreamer = true;
    }
    private void FixedUpdate()
    {
        if (isMinDistanceDefaultAttack) return;
        LookTarget();
        FollowTarget();
    }
    private void Update()
    {
        isFollowTarget = IsMinDistance(minDistanceFollowTarget);
        isLookTarget = IsMinDistance(minDistanceLookTarget);
        isMinDistanceDefaultAttack = IsMinDistance(minDistanceDefaultAttackTarget);
        if (isScreamer && isLookTarget)
        {
            StartCoroutine(ScreamWaitTime()); 
        }
    }
    private IEnumerator ScreamWaitTime()
    {
        onScream?.Invoke();
        onPlayAudioZombieScreamer?.Invoke();
        isScreamer = false;
        isIdle = true;
        yield return new WaitForSeconds(2.3f);
        isIdle = false;
    }
    public virtual void FollowTarget()
    {
        if (isFollowTarget && !isScreamer && !isIdle)
        {
            animZ.MoveAnim(1);
            Move(transform.forward);
        }
    }
    public virtual bool IsMinDistance(float minDistance)
    {
        distance = Vector3.Distance(transEnemy.position, transChar.position);
        if (distance <= minDistance)
            return true;
        else return false;
    }
    public virtual void LookTarget()
    {
        if (isFollowTarget && IsMinDistance(minDistanceLookTarget))
        {
            Vector3 direction = (transChar.position - transEnemy.position).normalized;
            Quaternion rotate = Quaternion.LookRotation(direction, Vector3.up);
            Rotate(rotate);
        }
    }
    public void Move(Vector3 position)
    {
        rigEnemy.MovePosition(rigEnemy.position + position * speedFollow * Time.fixedDeltaTime);
    }
    public void Rotate(Quaternion direction)
    {
        Quaternion smoothRotate = Quaternion.Slerp(transEnemy.rotation, direction, Time.fixedDeltaTime * speedRotate);
        rigEnemy.MoveRotation(smoothRotate);
    }
}
