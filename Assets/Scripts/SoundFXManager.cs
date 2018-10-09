using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    [SerializeField] AudioClip playerLaserSoundFX;
    [SerializeField] AudioClip explosionSoundFX;
    [SerializeField] AudioClip powerUpSoundFX;

    [SerializeField] AudioSource playerAudioSource;
    [SerializeField] AudioSource explosionAudioSource;
    [SerializeField] AudioSource powerUpAudioSource;


    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayerShootSound()
    {
        playerAudioSource.PlayOneShot(playerLaserSoundFX);
        playerAudioSource.volume = .1f;
        playerAudioSource.pitch = 3f;
    }

    public void ExplosionSound()
    {
        explosionAudioSource.PlayOneShot(explosionSoundFX);
        explosionAudioSource.volume = .1f;
    }

    public void PowerUpSound()
    {
        powerUpAudioSource.PlayOneShot(powerUpSoundFX);
        powerUpAudioSource.volume = .3f;
    }
}
