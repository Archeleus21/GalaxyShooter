using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    UIManager uiManager;
    Game_Manager gameManager;

    public static SpawnManager instance;

    [SerializeField] GameObject enemyShip;
    [SerializeField] GameObject playerShip;
    [SerializeField] GameObject playerOneCoOp;
    [SerializeField] GameObject playerTwoCoOp;
    [SerializeField] GameObject[] powerUps;

    Player player;
    Player player_1;
    Player player_2;

    float xRandom;
    float yRandom;

    public bool isGameStarted = false;

	// Use this for initialization
	void Awake ()
    {

	}
	
	// Update is called once per frame
	void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        StartGame();
    }

    private void Update()
    {
     
    }

    public void StartGame()
    {
        if(gameManager.isCoOpMode == false)
        {
            //single player
            Instantiate(playerShip, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
        else if(gameManager.isCoOpMode == true)
        {
            //player 1
            Instantiate(playerOneCoOp, new Vector3(-1f, 0f, 0f), Quaternion.identity);
            player_1 = GameObject.Find("Player_1(Clone)").GetComponent<Player>();
            player_1.isPlayer_1 = true;

            //player 2
            Instantiate(playerTwoCoOp, new Vector3(1f, 0f, 0f), Quaternion.identity);
            player_2 = GameObject.Find("Player_2(Clone)").GetComponent<Player>();
            player_2.isPlayer_2 = true;
        }

        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        uiManager.ResetScore();

        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(1f);

        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerUps());
    }

    IEnumerator SpawnEnemies()
    {
        if (gameManager.isCoOpMode == false)
        {
            player = GameObject.Find("Player(Clone)").GetComponent<Player>();

            while (gameManager.isGameOver == false)
            {
                xRandom = Random.Range(-8f, 8f);
                yRandom = Random.Range(-4f, 4f);

                if (gameManager.isGameOver == true)
                {
                    yield break;
                }
                else
                {
                    Instantiate(enemyShip, new Vector3(xRandom, 6f, 0f), Quaternion.identity, transform);
                }
                yield return new WaitForSeconds(2f);
            }
        }
        else if (gameManager.isCoOpMode == true)
        {
            Player player_1 = GameObject.Find("Player_1(Clone)").GetComponent<Player>();
            Player player_2 = GameObject.Find("Player_2(Clone)").GetComponent<Player>();

            while (gameManager.isGameOver == false)
            {
                xRandom = Random.Range(-8f, 8f);
                yRandom = Random.Range(-4f, 4f);

                if (gameManager.isGameOver == true)
                {
                    yield break;
                }
                else
                {
                    Instantiate(enemyShip, new Vector3(xRandom, 6f, 0f), Quaternion.identity, transform);
                }

                yield return new WaitForSeconds(2f);

            }
        }

        foreach (Transform children in transform)
        {
            Destroy(children.gameObject);
        }
    }

    IEnumerator SpawnPowerUps()
    {
        if (gameManager.isCoOpMode == false)
        {
            player = GameObject.Find("Player(Clone)").GetComponent<Player>();

            while (gameManager.isGameOver == false)
            {
                xRandom = Random.Range(-8f, 8f);
                yRandom = Random.Range(-4f, 4f);
                int powerUpRandomIndex = Random.Range(0, 3);

                yield return new WaitForSeconds(6f);

                if (gameManager.isGameOver == true)
                {
                    yield break;
                }
                else
                {
                    Instantiate(powerUps[powerUpRandomIndex], new Vector3(xRandom, yRandom, 0f), Quaternion.identity, transform);
                }
            }
        }
        else if (gameManager.isCoOpMode == true)
        {
            Player player_1 = GameObject.Find("Player_1(Clone)").GetComponent<Player>();
            Player player_2 = GameObject.Find("Player_2(Clone)").GetComponent<Player>();

            while (gameManager.isGameOver == false)
            {
                xRandom = Random.Range(-8f, 8f);
                yRandom = Random.Range(-4f, 4f);
                int powerUpRandomIndex = Random.Range(0, 3);

                yield return new WaitForSeconds(6f);

                if (gameManager.isGameOver == true)
                {
                    yield break;
                }
                else
                {
                    Instantiate(powerUps[powerUpRandomIndex], new Vector3(xRandom, yRandom, 0f), Quaternion.identity, transform);
                }
            }
        }
    }

}
