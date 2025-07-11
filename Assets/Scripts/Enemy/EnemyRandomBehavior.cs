using System;

public class EnemyRandomBehavior : RandomMoveBase
{  
    public override event Action onIdlePlayAudio;
 
    private void FixedUpdate()
    {
        isRandomMove = !move.isIdle && !move.isFollowTarget;
        isRandomRotate = !move.isLookTarget;
        if (move.isMinDistanceDefaultAttack) return;
        RandomMove();
        RandomRotate();
    }
    private void Update()
    {
        Idle();
        Threshold_Idle();
    }
    public override void OnIdlePlayAudioEvent()
    {
        onIdlePlayAudio?.Invoke();
    }
}
