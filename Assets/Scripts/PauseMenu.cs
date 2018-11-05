using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    Game_Manager gameManager;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] Animator animator;

    public bool isGamePaused = false;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
        
    }
    void PauseGame()
    {
        //pauseMenu.SetActive(true);
        animator.SetBool("Game_Paused", true);
        isGamePaused = true;
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        isGamePaused = false;
        animator.SetBool("Game_Paused", false);
        //pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        animator.SetBool("Game_Paused", false);
        //pauseMenu.SetActive(false);
        Time.timeScale = 1;

        gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        gameManager.isGameOver = true;
        StartCoroutine(gameManager.StartNewGame());
    }
}
