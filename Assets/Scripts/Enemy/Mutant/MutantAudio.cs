public class MutantAudio : AudioVoisBase
{
    private void OnEnable()
    {
        move.onScreamerPlayAudio += ScreamerAudioZ;
        hp.onDeadPlayAudio += DeathAudioZ;
        randomMove.onIdlePlayAudio += IdleAudioZ;
    }
    private void OnDisable()
    {
        move.onScreamerPlayAudio -= ScreamerAudioZ;
        hp.onDeadPlayAudio -= DeathAudioZ;
        randomMove.onIdlePlayAudio -= IdleAudioZ;
    }
}
