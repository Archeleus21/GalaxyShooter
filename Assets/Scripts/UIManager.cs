using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image playerLivesImage;
    [SerializeField] Text playerScore;
    [SerializeField] Sprite[] playerLivesImages;

    //UpdateLives()
   public void RemainingPlayerLives(int playerLives)
    {
        switch(playerLives)
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
    
    //UpdateScore()
    public void PlayerScore()
    {

    }

}
