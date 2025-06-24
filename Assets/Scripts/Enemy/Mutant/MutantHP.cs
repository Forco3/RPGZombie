using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantHP : HitPointsBase
{
    public override event Action onDeadPlayAudio;

    public override void OnTakeDamagePlayAudioDeadEvent()
    {
        onDeadPlayAudio?.Invoke();
    }  
}
