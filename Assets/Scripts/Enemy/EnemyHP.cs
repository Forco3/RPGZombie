using System;

public class EnemyHP : HitPointsBase
{       
    public override event Action onDeadPlayAudio;

    public override void OnTakeDamagePlayAudioDeadEvent()
    {
        onDeadPlayAudio?.Invoke();
    }
}
