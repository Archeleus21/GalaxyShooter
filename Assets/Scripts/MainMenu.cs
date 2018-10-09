using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Image mainMenu;

    SpawnManager spawnManager;
    UIManager uiManager;

    public bool isGameStarted = false;

    // Use this for initialization
    void Awake()
    {

        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RestartGame();
    }

    public void RestartGame()
    {
        if (isGameStarted == false )
        {
            mainMenu.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGameStarted = true;
                mainMenu.gameObject.SetActive(false);
                spawnManager.StartGame();
                uiManager.ResetScore();
            }
        }
    }
}
