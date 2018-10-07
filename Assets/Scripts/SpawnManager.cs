using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyShip;
    [SerializeField] GameObject[] powerUps;

    PlayerAbilities playerAbilities;

    int playerLives;

    float xRandom;
    float yRandom;

    float powerUpSpawnRate;

	// Use this for initialization
	void Awake ()
    {

	}
	
	// Update is called once per frame
	void Start ()
    {
        playerAbilities = GameObject.Find("Player").GetComponent<PlayerAbilities>();
        playerLives = GameObject.Find("Player").GetComponent<Player>().playerLives;

        if(playerLives > 0)
        {
            StartCoroutine(SpawnEnemies());
            StartCoroutine(SpawnPowerUps());

        }

	}

    private void Update()
    {

    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            xRandom = Random.Range(-8f, 8f);
            yRandom = Random.Range(-4f, 4f);

            Instantiate(enemyShip, new Vector3(xRandom, 6f, 0f), Quaternion.identity, transform);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            xRandom = Random.Range(-8f, 8f);
            yRandom = Random.Range(-4f, 4f);

            yield return new WaitForSeconds(6f);
            Instantiate(powerUps[0], new Vector3(xRandom, yRandom, 0f), Quaternion.identity, transform);
            yield return new WaitForSeconds(10f);
            Instantiate(powerUps[1], new Vector3(xRandom, yRandom, 0f), Quaternion.identity, transform);

            if (playerAbilities.isShieldActive == true)
            {
                //do nothing
            }
            else
            {
                Instantiate(powerUps[2], new Vector3(xRandom, yRandom, 0f), Quaternion.identity, transform);
                yield return new WaitForSeconds(15f);
            }
        }
    }
}
