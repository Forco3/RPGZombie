using System;
using System.Collections;
using UnityEngine;

public abstract class RandomMoveBase : MonoBehaviour
{
    public abstract event Action onIdlePlayAudio;
    public MoveBase move { get; private set; }
    public AnimBase anim { get; private set; }

    public Transform tr { get; private set; }

    public Quaternion direction;

    public float randomTimer { get; set; } = 5;
    public float minValloueTime { get; private set; } = 3;
    public float maxValloueTime { get; private set; } = 6;

    public bool isRandomRotate;
    public bool isRandomMove;

    public float minAngle { get; private set; } = 30;
    public float maxAngle { get; private set; } = 180;

    public float timeIdle { get; private set; } = 5;
     
    private void Awake()
    {
        move = GetComponent<MoveBase>();
        anim = GetComponent<AnimBase>();
        tr = GetComponent<Transform>();
    }
    public abstract void OnIdlePlayAudioEvent();
    protected void Idle()
    {
        if (move.isIdle && !isRandomMove && !move.isFollowTarget)
        {
            anim.MoveAnim(0);
            StartCoroutine(WaitIdle());
            OnIdlePlayAudioEvent();
        }
    }
    protected void RandomMove()
    {
        if (isRandomMove)
        {
            anim.MoveAnim(1);
            move.Move(tr.forward);
        }
    }
    protected void RandomRotate()
    {
        if (isRandomRotate)
        {
            float y = tr.eulerAngles.y;
            float angle = UnityEngine.Random.Range(minAngle, maxAngle);
            if (UnityEngine.Random.value < 0.5f) angle *= -1;
            float newY = y + angle;
            direction = Quaternion.Euler(0, newY, 0);
            move.Rotate(direction);
        }

    }

    protected void Threshold_Idle()
    {
        randomTimer -= Time.deltaTime;
        if (randomTimer <= 0)
        {
            move.isIdle = !move.isFollowTarget;
            randomTimer = UnityEngine.Random.Range(minValloueTime, maxValloueTime);
        }
    }
    protected IEnumerator WaitIdle()
    {
        move.isIdle = true;
        yield return new WaitForSeconds(timeIdle);
        move.isIdle = false;
    }
}
