using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEffects : MonoBehaviour
{
    private WeaponHan weaponHandler;

    private AudioSource weaponSource;
    [Header("Audio and ParticleEffects")]
    public AudioClip weaponClip;
    public ParticleSystem weaponParticleSystem;
    [Range(0.1f, 1)]
    [SerializeField]private float interval = 0.5f;
    private float nextTime;
    private void Awake()
    {
        weaponSource = GetComponent<AudioSource>();
        weaponHandler = FindObjectOfType<WeaponHan>();
    }
    private void Update()
    {
        if (Time.time > nextTime && Input.GetMouseButton(0) && weaponHandler.isPickUpWeapon) 
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
