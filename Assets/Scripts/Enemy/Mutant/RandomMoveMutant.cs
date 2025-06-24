using System;

public class RandomMoveMutant : RandomMoveBase
{
    public override event Action onIdlePlayAudio;
    private void FixedUpdate()
    {
        isRandomMove = !move.isIdle && !move.isFollowTarget;
        isRandomRotate = !move.isLookTarget;
        if (move.isMinDistanceDefaultAttack || move.isMinDistanceJumpAttack || move.isMinDistancePunchAttack) return;
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
