using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    Game_Manager gameManager;

    private void Start()
    {

    }
    public void LoadSinglePlayerGame()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        gameManager.isCoOpMode = false;
        SceneManager.LoadScene("Single_Player");
    }

    public void LoadCoOpModeGame()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        gameManager.isCoOpMode = true;
        SceneManager.LoadScene("Co-Op_Mode");
    }
}
