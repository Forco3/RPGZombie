using System;


public class EnemyMove : MoveBase
{
    public override event Action onScreamPlayAnim;
    public override event Action onScreamerPlayAudio;
    private void FixedUpdate()
    {
        if (isMinDistanceDefaultAttack) return;
        LookTarget();
        FollowTarget();
    }

    public override void OnScreamPlayAnimEvent()
    {
        onScreamPlayAnim?.Invoke();
    }
    public override void OnScreamPlayAudioEvent()
    {
        onScreamerPlayAudio?.Invoke();
    }
}
