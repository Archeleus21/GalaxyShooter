using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    PlayerAbilities playerAbilities;

    public int playerLives = 3;
    public float playerMovementSpeed = 10f;
    
    // Use this for initialization
    void Start ()
    {
        transform.position = new Vector3(0, 0, 0);
        animator = GetComponent<Animator>();
        playerAbilities = GetComponent<PlayerAbilities>() as PlayerAbilities;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        PlayerMovement();
    }

    private void Update()
    {
        PlayerShooting();
    }

    //used to control movement
    void PlayerMovement()
    {
        float Ymovement = Input.GetAxis("Vertical");  //used for key input from -1 - 1 increments by decimals
        float Xmovement = Input.GetAxis("Horizontal");  //used for key input from -1 - 1 increments by decimals

        PlayerVerticalMovement(Ymovement);
        PlayerTurnAnimation(Xmovement);
        PlayerHorizontalMovement(Xmovement);
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

    //movemet on X axis
    private void PlayerHorizontalMovement(float Xmovement)
    {
        if (Input.GetButton("Horizontal"))
        {
            PlayerWidthLimit();
            transform.Translate(Xmovement * playerMovementSpeed * Time.deltaTime, 0f, 0f);
        }
    }

    //uses booleans to play animations
    void PlayerTurnAnimation(float Xmovement)
    {
        if(Xmovement < 0)
        {
            animator.SetBool("Turn Left", true);
        }
        else if (Xmovement == 0)
        {
            animator.SetBool("Turn Left", false);
        }

        if(Xmovement > 0)
        {
            animator.SetBool("Turn Right", true);
        }
        else if (Xmovement == 0)
        {
            animator.SetBool("Turn Right", false);
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

    public void TakeDamage()
    {
        playerLives--;

        if(playerLives <= 0)
        {
            Destroy(gameObject);
        }
    }
}
