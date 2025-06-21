using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMutantBehaviour : EnemyRandomBehavior
{
    private MutantMove moveM;
    private MutantAnimator animM;

    private Transform trM;

    private Quaternion direction;

    private void Awake()
    {
        moveM = GetComponent<MutantMove>();
        animM = GetComponent<MutantAnimator>();
        trM = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        isRandomMove = !moveM.isIdle && !moveM.isFollowTarget;
        isRandomRotate = !moveM.isLookTarget;
        if (moveM.isMinDistanceDefaultAttack || moveM.isMinDistanceJumpAttack || moveM.isMinDistancePunchAttack) return;
        RandomMove();
        RandomRotate();
    }
    private void Update()
    {
        Idle();
        SetRandomTimer();
    }
    public override void RandomMove()
    {
        if (isRandomMove)
        {
            animM.MoveAnim(1);
            moveM.Move(trM.forward);
        }
    }
    public override void RandomRotate()
    {
        if (isRandomRotate)
        {
            float y = trM.eulerAngles.y;
            float angle = UnityEngine.Random.Range(minAngle, maxAngle);
            if (UnityEngine.Random.value < 0.5f) angle *= -1;
            float newY = y + angle;
            direction = Quaternion.Euler(0, newY, 0);
            moveM.Rotate(direction);
        }
    }
    public override void Idle()
    {
        if (moveM.isIdle && !isRandomMove && !moveM.isFollowTarget)
        {
            animM.MoveAnim(0);
            StartCoroutine(WaitIdle());
            //onPlayAudioZombieIdle?.Invoke();
        }
    }
    public override void SetRandomTimer()
    {
        randomTimer -= Time.deltaTime;
        if (randomTimer <= 0)
        {
            moveM.isIdle = !moveM.isFollowTarget;
            randomTimer = UnityEngine.Random.Range(minValloueTime, maxValloueTime);
        }
    }
    public override IEnumerator WaitIdle()
    {
        moveM.isIdle = true;
        yield return new WaitForSeconds(timeIdle);
        moveM.isIdle = false;
    }
}
