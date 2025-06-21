using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudio : MonoBehaviour
{
    private EnemyMove moveZ;
    private EnemyHP hpZ;
    private EnemyRandomBehavior randomBehaviorZ;

    public AudioSource idleSource;
    public AudioSource screamerSource;
    public AudioSource deathSource;

    private void Awake()
    {
        moveZ = GetComponentInParent<EnemyMove>();
        randomBehaviorZ = GetComponentInParent<EnemyRandomBehavior>();
        hpZ = GetComponentInParent<EnemyHP>();
        idleSource = transform.GetChild(0).GetComponent<AudioSource>();
        screamerSource = transform.GetChild(1).GetComponent<AudioSource>();
        deathSource = transform.GetChild(2).GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        moveZ.onPlayAudioZombieScreamer += ScreamerAudioZ;
        hpZ.onPlayAudioZombieDeath += DeathAudioZ;
        randomBehaviorZ.onPlayAudioZombieIdle += IdleAudioZ;
    }
    private void OnDisable()
    {
        moveZ.onPlayAudioZombieScreamer -= ScreamerAudioZ;
        hpZ.onPlayAudioZombieDeath -= DeathAudioZ;
        randomBehaviorZ.onPlayAudioZombieIdle -= IdleAudioZ;
    }
    private void Start()
    {
        IdleAudioZ();
    }
    private void IdleAudioZ()
    {
        idleSource.Play();
    }
    private void DeathAudioZ()
    {
        idleSource.Stop();
        deathSource.Play();
    }
    private void ScreamerAudioZ()
    {
        screamerSource.Play();
    }
}
