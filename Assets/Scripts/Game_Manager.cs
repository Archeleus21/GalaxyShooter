using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Player player_1;
    [SerializeField] Player player_2;

    public static Game_Manager instance = null;
    public bool isCoOpMode = false;
    public bool isPlayerDead;
    public bool isPlayer_1Dead;
    public bool isPlayer_2Dead;
    public bool isGameOver;

    // Use this for initialization
    void Awake ()
    {
        GameManagerSingleton();
	}
	
	// Update is called once per frame
	void Update ()
    {
        VerifyGameOver();
    }

    void GameManagerSingleton()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    public void VerifyGameOver()
    {
        if (isPlayer_1Dead == true && isPlayer_2Dead == true || isPlayerDead == true)
        {
            isGameOver = true;
            StartCoroutine(StartNewGame());
        }
    }

    public IEnumerator StartNewGame()
    {
        print("Starting new Game...");

        yield return new WaitForSeconds(1f);

        if (isGameOver == true)
        {
            isGameOver = false;
            isPlayerDead = false;
            isPlayer_1Dead = false;
            isPlayer_2Dead = false;
            SceneManager.LoadScene("Main_Menu");
        }
    }
}
