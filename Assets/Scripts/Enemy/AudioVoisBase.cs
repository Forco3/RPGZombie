using UnityEngine;

public abstract class AudioVoisBase : MonoBehaviour
{
    public MoveBase move { get; private set; }
    public HitPointsBase hp { get; private set; }
    public RandomMoveBase randomMove { get; private set; }

    public AudioSource idleSource { get; private set; }
    public AudioSource screamerSource { get; private set; }
    public AudioSource deathSource { get; private set; }

    private void Awake()
    {
        move = GetComponentInParent<MoveBase>();
        randomMove = GetComponentInParent<RandomMoveBase>();
        hp = GetComponentInParent<HitPointsBase>();
        idleSource = transform.GetChild(0).GetComponent<AudioSource>();
        screamerSource = transform.GetChild(1).GetComponent<AudioSource>();
        deathSource = transform.GetChild(2).GetComponent<AudioSource>();
    }
    private void Start()
    {
        IdleAudioZ();
    }
    protected void IdleAudioZ()
    {
        idleSource.Play();
    }
    protected void DeathAudioZ()
    {
        idleSource.Stop();
        deathSource.Play();
    }
    protected void ScreamerAudioZ()
    {
        screamerSource.Play();
    }
}
