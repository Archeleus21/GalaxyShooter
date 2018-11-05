using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Animator player_1Animator;
    Animator player_2Animator;
    PlayerAbilities playerAbilities;
    UIManager uiManager;
    SoundFXManager soundFX;
    Game_Manager gameManager;

    public Transform playerShipID;

    [SerializeField] GameObject playerExplosionPrefab;
    [SerializeField] GameObject leftEngineFire;
    [SerializeField] GameObject rightEngineFire;

    public int playerLives = 3;
    public float playerMovementSpeed = 10f;

    public bool isPlayer_1 = false;
    public bool isPlayer_2 = false;

    public int player_1Lives = 3;

    public int player_2Lives = 3;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
        player_2Animator = GetComponent<Animator>();
        player_1Animator = GetComponent<Animator>();
        playerAbilities = gameObject.GetComponent<PlayerAbilities>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        soundFX = GameObject.Find("SoundFX Manager").GetComponent<SoundFXManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>();

        if (gameManager.isCoOpMode == false)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        else if(gameManager.isCoOpMode == true)
        {
            //do nothing
        }        
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        PlayerMovement();
    }

    private void Update()
    {
        if (gameManager.isCoOpMode == false)
        {
            PlayerShooting();
        }
        else if (gameManager.isCoOpMode == true)
        {
            if (isPlayer_1 == true)
            {
                Player_1Shooting();
            }
            if (isPlayer_2 == true)
            {
                Player_2Shooting();
            }
        }

        if (gameManager.isCoOpMode == false)
        {
            uiManager.RemainingPlayerLives(playerLives);
        }
        else if(gameManager.isCoOpMode == true)
        {
            if(isPlayer_1 == true && isPlayer_2  == false)
            {
                uiManager.RemainingPlayer_1Lives(playerLives);
            }
            if(isPlayer_2 == true && isPlayer_1 ==  false)
            {
                uiManager.RemainingPlayer_2Lives(playerLives);
            }
        }
    }

    //used to control movement
    void PlayerMovement()
    {
        float Ymovement = Input.GetAxis("Vertical");  //used for key input from -1 - 1 increments by decimals
        float Xmovement = Input.GetAxis("Horizontal");  //used for key input from -1 - 1 increments by decimals

        float Ymovement_Player_1 = Input.GetAxis("Vertical");  //used for key input from -1 - 1 increments by decimals
        float Xmovement_Player_1 = Input.GetAxis("Horizontal");  //used for key input from -1 - 1 increments by decimals

        float Ymovement_Player_2 = Input.GetAxis("Vertical2");  //used for key input from -1 - 1 increments by decimals
        float Xmovement_Player_2 = Input.GetAxis("Horizontal2");  //used for key input from -1 - 1 increments by decimals

        if (gameManager.isCoOpMode == false)
        {
            PlayerVerticalMovement(Ymovement);
            PlayerHorizontalMovement(Xmovement);
            PlayerTurnAnimation(Xmovement);
        }
        else if(gameManager.isCoOpMode == true)
        {
            if (isPlayer_1 == true && isPlayer_2 == false)
            {
                Player_1VerticalMoment(Ymovement_Player_1);
                Player_1HorizontalMovement(Xmovement_Player_1);
                Player_1TurnAnimation(Xmovement_Player_1);
            }
            if (isPlayer_2 == true && isPlayer_1 == false)
            {
                Player_2VerticalMovement(Ymovement_Player_2);
                Player_2HorizontalMovement(Xmovement_Player_2);
                Player_2TurnAnimation(Xmovement_Player_2);
            }
        }

    }

    //movement on Y axis
    private void PlayerVerticalMovement(float Ymovement)
    {        
        if (Input.GetButton("Vertical"))
        {
            PlayerHeightLimit();
            transform.Translate(0f, Ymovement * playerMovementSpeed * Time.deltaTime, 0f);
        }
    }
    private void Player_1VerticalMoment(float Ymovement)
    {
        if (isPlayer_1 == true && isPlayer_2 == false)
        {
            if (Input.GetButton("Vertical"))
            {
                PlayerHeightLimit();
                transform.Translate(0f, Ymovement * playerMovementSpeed * Time.deltaTime, 0f);
            }
        }
    }
    private void Player_2VerticalMovement(float Ymovement)
    {
        if(isPlayer_2 == true && isPlayer_1 == false)
        {
            if(Input.GetButton("Vertical2"))
            {
                PlayerHeightLimit();
                transform.Translate(0f, Ymovement * playerMovementSpeed * Time.deltaTime, 0f);
            }
        }
    }

    //movemet on X axis
    private void PlayerHorizontalMovement(float Xmovement)
    {       
        if (Input.GetButton("Horizontal"))
        {
            PlayerWidthLimit();
            transform.Translate(Xmovement * playerMovementSpeed * Time.deltaTime, 0f, 0f);
        }        
    }

    private void Player_1HorizontalMovement(float Xmovement)
    {
        if (isPlayer_1 == true)
        {
            if (Input.GetButton("Horizontal"))
            {
                PlayerWidthLimit();
                transform.Translate(Xmovement * playerMovementSpeed * Time.deltaTime, 0f, 0f);
            }
        }
    }

    private void Player_2HorizontalMovement(float Xmovement)
    {
        if (isPlayer_2 == true)
        {
            if (Input.GetButton("Horizontal2"))
            {
                PlayerWidthLimit();
                transform.Translate(Xmovement * playerMovementSpeed * Time.deltaTime, 0f, 0f);
            }
        }
    }

    //uses booleans to play animations
    void PlayerTurnAnimation(float Xmovement)
    {
        if (Xmovement < 0)
        {
            animator.SetBool("Turn Left", true);
            animator.SetBool("Turn Right", false);
        }
        else if (Xmovement > 0)
        {
            animator.SetBool("Turn Right", true);
            animator.SetBool("Turn Left", false);
        }
        else
        {
            animator.SetBool("Turn Left", false);
            animator.SetBool("Turn Right", false);
        }
    }

    void Player_1TurnAnimation(float Xmovement)
    {
        if (Xmovement < 0)
        {
            player_1Animator.SetBool("Turn Left", true);
            player_1Animator.SetBool("Turn Right", false);
        }
        else if (Xmovement > 0)
        {
            player_1Animator.SetBool("Turn Right", true);
            player_1Animator.SetBool("Turn Left", false);
        }
        else
        {
            player_1Animator.SetBool("Turn Left", false);
            player_1Animator.SetBool("Turn Right", false);
        }
    }
    void Player_2TurnAnimation(float Xmovement)
    {
        if (Xmovement < 0)
        {
            player_2Animator.SetBool("Turn Left", true);
            player_2Animator.SetBool("Turn Right", false);
        }
        else if (Xmovement > 0)
        {
            player_2Animator.SetBool("Turn Right", true);
            player_2Animator.SetBool("Turn Left", false);
        }
        else
        {
            player_2Animator.SetBool("Turn Left", false);
            player_2Animator.SetBool("Turn Right", false);
        }
    }

    //keeps player on screen
    private void PlayerWidthLimit()
    {
        if (transform.position.x >= 8f)
        {
            transform.position = new Vector3(8f, transform.position.y, 0f);
        }
        else if (transform.position.x <= -8f)
        {
            transform.position = new Vector3(-8f, transform.position.y, 0f);
        }
    }
    
    //keeps player on screen
    private void PlayerHeightLimit()
    {
        if (transform.position.y >= 4f)
        {
            transform.position = new Vector3(transform.position.x, 4f, 0f);
        }
        else if (transform.position.y <= -4f)
        {
            transform.position = new Vector3(transform.position.x, -4f, 0f);
        }
    }

    //allows player to shoot
    void PlayerShooting()
    {
        if(Input.GetButton("Fire1"))
        {
            playerAbilities.ShootLaserBeam();  //gets method/function from other script on same Game Object
        }
    }

    void Player_1Shooting()
    {
        if(Input.GetButton("Fire1"))
        {
            playerAbilities.ShootLaserBeam();  //gets method/function from other script on same Game Object
        }
    }

    void Player_2Shooting()
    {
        if(Input.GetButton("Fire2"))
        {
            playerAbilities.ShootLaserBeam();  //gets method/function from other script on same Game Object
        }
    }

    public void TakeDamage()
    {
        if (gameManager.isCoOpMode == false)
        {
            playerLives--;
            uiManager.RemainingPlayerLives(playerLives);
            DamageAnimation();

            if (playerLives <= 0)
            {
                gameManager.isPlayerDead = true;
                PlayerDeath();
                soundFX.ExplosionSound();
                Destroy(gameObject);
            }
        }
        else if(gameManager.isCoOpMode == true)
        {
            if (isPlayer_1 == true && isPlayer_2 == false)
            {
                playerLives--;
                uiManager.RemainingPlayer_1Lives(playerLives);
                DamageAnimation();

                if (playerLives <= 0)
                {
                    gameManager.isPlayer_1Dead = true;
                    PlayerDeath();
                    soundFX.ExplosionSound();
                    Destroy(gameObject);
                }
            }
            if (isPlayer_2 == true && isPlayer_1 == false)
            {
                playerLives--;
                uiManager.RemainingPlayer_2Lives(playerLives);
                DamageAnimation();

                if (playerLives <= 0)
                {
                    gameManager.isPlayer_2Dead = true;
                    PlayerDeath();
                    soundFX.ExplosionSound();
                    Destroy(gameObject);
                }
            }

        }
    }

    void PlayerDeath()
    {
        Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);  //explosion
    }

    void DamageAnimation()
    {
        if(playerLives == 2)
        {
            leftEngineFire.SetActive(true);
        }
        else if(playerLives == 1)
        {
            rightEngineFire.SetActive(true);
        }
        else
        {
            leftEngineFire.SetActive(false);
            rightEngineFire.SetActive(false);
        }
    }
}
