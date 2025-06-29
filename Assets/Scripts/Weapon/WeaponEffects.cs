using UnityEngine;

public class WeaponEffects : MonoBehaviour
{
    private CharacterState state;

    private AudioSource weaponSource;
    [Header("Audio and ParticleEffects")]
    public AudioClip weaponClip;
    public ParticleSystem weaponParticleSystem;
    [Range(0.1f, 1)]
    [SerializeField]private float interval = 0.2f;
    private float nextTime;
    private void Awake()
    {
        weaponSource = GetComponent<AudioSource>();
        state = FindObjectOfType<CharacterState>();
    }
    private void Update()
    {
        if (Time.time > nextTime && state.isFire) 
        {
            nextTime = Time.time + interval;
            PlayShootingAudio(true);
        }
    }
    private void PlayShootingAudio(bool isLeftMouseButtonDown)
    {
        if (isLeftMouseButtonDown)
        {
            weaponSource.PlayOneShot(weaponClip);
            weaponParticleSystem.Play();
        }
    }
}
