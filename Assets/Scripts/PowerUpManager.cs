using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    GameObject powerUps;
    Animator animator;
    SoundFXManager soundFX;

    public int powerUpID;  //tripleshot = 0, speedboost = 1, shield = 2

    float timer;

    // Use this for initialization
    void Start()
    {
        powerUps = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        soundFX = GameObject.Find("SoundFX Manager").GetComponent<SoundFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        animator.SetTrigger("PowerUp Animation");
    }

    void SpawnPowerUps()
    {
        Instantiate(powerUps, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.name == "Player(Clone)")
        {
            PlayerAbilities playerAbilities = otherObj.GetComponent<PlayerAbilities>();  //gets player script access

            if (playerAbilities != null)  //ensure player was the one that collided with object
            {
                soundFX.PowerUpSound();

                switch (powerUpID)
                {
                    case 0:
                        playerAbilities.ActivateTripleShotPowerUp();
                        break;
                    case 1:
                        playerAbilities.ActivateSpeedBoostPowerUp();
                        break;
                    case 2:
                        playerAbilities.isShieldActive = true;
                        playerAbilities.ActivateShield();
                        break;
                    default:
                        print("no powerup ID found");
                        break;
                }
                Destroy(gameObject);
            }
        }
    }
}
