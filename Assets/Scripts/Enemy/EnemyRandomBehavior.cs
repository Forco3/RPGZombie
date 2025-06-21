using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyRandomBehavior : MonoBehaviour
{
    private EnemyMove moveZ;
    private EnemyAnimator animZ;

    private Transform transZ;

    private Quaternion direction;

    public float randomTimer = 5;
    public float minValloueTime = 3;
    public float maxValloueTime = 6;

    public bool isRandomRotate;
    public bool isRandomMove;

    public float minAngle = 30;
    public float maxAngle = 180;

    public float timeIdle = 5;

    public event Action onPlayAudioZombieIdle;

    private void Awake()
    {
        moveZ = GetComponent<EnemyMove>();
        animZ = GetComponent<EnemyAnimator>();
        transZ = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        isRandomMove = !moveZ.isIdle && !moveZ.isFollowTarget;
        isRandomRotate = !moveZ.isLookTarget;
        if (moveZ.isMinDistanceDefaultAttack) return;
        RandomMove();
        RandomRotate();
    }
    private void Update()
    {
        Idle();
        SetRandomTimer();
    }
    public virtual void RandomMove()
    {
        if (isRandomMove)
        {
            animZ.MoveAnim(1);
            moveZ.Move(transZ.forward);
        }
    }
    public virtual void RandomRotate()
    {
        if (isRandomRotate)
        {
            float y = transZ.eulerAngles.y;
            float angle = UnityEngine.Random.Range(minAngle, maxAngle);
            if (UnityEngine.Random.value < 0.5f) angle *= -1;
            float newY = y + angle;
            direction = Quaternion.Euler(0, newY, 0);
            moveZ.Rotate(direction);
        }
        
    }
    public virtual void Idle()
    {
        if (moveZ.isIdle && !isRandomMove && !moveZ.isFollowTarget)
        {
            animZ.MoveAnim(0);
            StartCoroutine(WaitIdle());
            onPlayAudioZombieIdle?.Invoke();
        }  
    }
    public virtual void SetRandomTimer()
    {
        randomTimer -= Time.deltaTime;
        if (randomTimer <= 0)
        {
            moveZ.isIdle = !moveZ.isFollowTarget;
            randomTimer = UnityEngine.Random.Range(minValloueTime, maxValloueTime);
        }
    }
    public virtual IEnumerator WaitIdle()
    {
        moveZ.isIdle = true;
        yield return new WaitForSeconds(timeIdle);
        moveZ.isIdle = false;
    }
}
