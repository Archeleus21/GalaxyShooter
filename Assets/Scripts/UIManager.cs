using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    Game_Manager gameManager;

    [SerializeField] Image playerLivesImage;
    [SerializeField] Text playerScoreText;
    [SerializeField] Sprite[] playerLivesImages;

    [SerializeField] Image player_1LivesImage;
    [SerializeField] Text player_1ScoreText;
    [SerializeField] Sprite[] player_1LivesImages;

    [SerializeField] Image player_2LivesImage;
    [SerializeField] Text player_2ScoreText;
    [SerializeField] Sprite[] player_2LivesImages;

    public int playerScore = 0;
    public int player_1Score = 0;
    public int player_2Score = 0;


    private void Start()
    {

    }

    //UpdateLives()
    public void RemainingPlayerLives(int playerLives)
    {

        switch (playerLives)
        {
            case 1:
                playerLivesImage.sprite = playerLivesImages[1];
                break;
            case 2:
                playerLivesImage.sprite = playerLivesImages[2];
                break;
            case 3:
                playerLivesImage.sprite = playerLivesImages[3];
                break;
            default:
                playerLivesImage.sprite = playerLivesImages[0];
                break;
        }
    }

    //UpdateLives()
    public void RemainingPlayer_1Lives(int playerLives)
    {

        switch (playerLives)
        {
            case 1:
                player_1LivesImage.sprite = player_1LivesImages[1];
                break;
            case 2:
                player_1LivesImage.sprite = player_1LivesImages[2];
                break;
            case 3:
                player_1LivesImage.sprite = player_1LivesImages[3];
                break;
            default:
                player_1LivesImage.sprite = player_1LivesImages[0];
                break;
        }
    }

    //UpdateLives()
    public void RemainingPlayer_2Lives(int playerLives)
    {
        switch (playerLives)
        {
            case 1:
                player_2LivesImage.sprite = player_2LivesImages[1];
                break;
            case 2:
                player_2LivesImage.sprite = player_2LivesImages[2];
                break;
            case 3:
                player_2LivesImage.sprite = player_2LivesImages[3];
                break;
            default:
                player_2LivesImage.sprite = player_2LivesImages[0];
                break;
        }
    }

    //UpdateScore()
    public void PlayerScore()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>();

        playerScore += 10;
        playerScoreText.GetComponent<Text>().text = playerScore.ToString();
    }

    public void Player_1Score()
    {
        player_1Score += 10;
        player_1ScoreText.GetComponent<Text>().text = player_1Score.ToString();
    }

    public void Player_2Score()
    {
        player_2Score += 10;
        player_2ScoreText.GetComponent<Text>().text = player_2Score.ToString();
    }

    public void ResetScore()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>();

        if (gameManager.isCoOpMode == false)
        {
            playerScore = 0;
            playerScoreText.text = playerScore.ToString();
        }
        else if (gameManager.isCoOpMode == true)
        {
            player_1Score = 0;
            player_2Score = 0;

            player_1ScoreText.text = playerScore.ToString();
            player_2ScoreText.text = playerScore.ToString();
        }
    }
}
