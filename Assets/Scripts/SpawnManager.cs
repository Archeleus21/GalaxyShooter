using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyShip;
    [SerializeField] GameObject playerShip;
    [SerializeField] GameObject[] powerUps;

    Player player;

    float xRandom;
    float yRandom;

	// Use this for initialization
	void Awake ()
    {

	}
	
	// Update is called once per frame
	void Start ()
    {

    }

    private void Update()
    {

    }

    IEnumerator SpawnEnemies()
    {
        while (player.isPlayerDead == false)
        {
            xRandom = Random.Range(-8f, 8f);
            yRandom = Random.Range(-4f, 4f);

            Instantiate(enemyShip, new Vector3(xRandom, 6f, 0f), Quaternion.identity, transform);
            yield return new WaitForSeconds(2f);
        }

        foreach (Transform children in transform)
        {
            Destroy(children.gameObject);
        }
    }

    IEnumerator SpawnPowerUps()
    {
        while (player.isPlayerDead == false)
        {
            xRandom = Random.Range(-8f, 8f);
            yRandom = Random.Range(-4f, 4f);
            int powerUpRandomIndex = Random.Range(0, 3);

            yield return new WaitForSeconds(6f);

            if (player.isPlayerDead == true)
            {
                yield break;
            }
            else
            {
                Instantiate(powerUps[powerUpRandomIndex], new Vector3(xRandom, yRandom, 0f), Quaternion.identity, transform);

            }
        }
    }

    public void StartGame()
    {
        Instantiate(playerShip, new Vector3(0f, 0f, 0f), Quaternion.identity);

        player = GameObject.Find("Player(Clone)").GetComponent<Player>();
        player.isPlayerDead = false;

        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(1f);

        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerUps());
    }
}
