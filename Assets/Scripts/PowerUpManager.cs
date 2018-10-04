using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    //[SerializeField] GameObject tripleShotPrefab;
    //[SerializeField] GameObject speedBoostPrefab;

    GameObject powerUps;
    Animator animator;

    public int powerUpID;  //tripleshot = 1, speedboost = 2, shield = 3

    float timer;

    // Use this for initialization
    void Start()
    {
        powerUps = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
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
        if (otherObj.name == "Player")
        {
            PlayerAbilities playerShoot = otherObj.GetComponent<PlayerAbilities>();  //gets player script access

            if (playerShoot != null)  //ensure player was the one that collided with object
            {
                switch (powerUpID)
                {
                    case 0:
                        playerShoot.ActivateTripleShotPowerUp();
                        break;
                    case 1:
                        playerShoot.ActivateSpeedBoostPowerUp();
                        break;
                    case 2:
                        //playerShoot.ActivateShieldPowerUp();
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
