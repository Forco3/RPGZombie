using System;

public class MutantMove :MoveBase
{
    public override event Action onScreamPlayAnim;
    public override event Action onScreamerPlayAudio;
     
    private void FixedUpdate()
    {
        if (isMinDistanceDefaultAttack || isMinDistancePunchAttack || isMinDistanceJumpAttack) return;
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
