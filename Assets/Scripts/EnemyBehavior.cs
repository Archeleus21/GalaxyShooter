using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject deathExplosionPrefab;
    [SerializeField] float enemyMovementSpeed = 2f;

    UIManager uiManager;
    SoundFXManager soundFX;

    // Use this for initialization
    void Start ()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        soundFX = GameObject.Find("SoundFX Manager").GetComponent<SoundFXManager>();
    }

    // Update is called once per frame
    void Update ()
    {
        EnemyMovement();
	}

    void EnemyMovement()
    {
        transform.Translate(0f, -enemyMovementSpeed * Time.deltaTime, 0f);
        //transform.right = targetPlayer.transform.position - transform.position;

        float randomX = Random.Range(-8f, 8f);

        if (transform.position.y <= -7f)
        {
            transform.position = new Vector3(randomX, 8f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.name == "Laser(Clone)" || otherObj.name == "Triple Shot(Clone)" || otherObj.name == "Triple Shot")
        {
            Player player = otherObj.GetComponentInParent<Player>();

            if(player.isPlayer_1 == true)
            {
                uiManager.Player_1Score();
            }
            if(player.isPlayer_2 == true)
            {
                uiManager.Player_2Score();
            }
            else
            {
                uiManager.PlayerScore();
            }

            CreateEnemyDeathExplosion();
            soundFX.ExplosionSound();
            Destroy(otherObj.gameObject);
            Destroy(gameObject);
        }
        else if(otherObj.name == "Player(Clone)" || otherObj.name == "Player_1(Clone)" || otherObj.name == "Player_2(Clone)")
        {
            Player player = otherObj.GetComponent<Player>();

            if(player != null)
            {
                CheckForPlayerShield(player);
            }
        }
    }

    private void CheckForPlayerShield(Player player)
    {
        if (player.GetComponent<PlayerAbilities>().isShieldActive == true)
        {
            player.GetComponent<PlayerAbilities>().isShieldActive = false;
            player.GetComponent<PlayerAbilities>().ActivateShield();
            uiManager.PlayerScore();
            CreateEnemyDeathExplosion();
            soundFX.ExplosionSound();
            Destroy(gameObject);
        }
        else
        {
            uiManager.PlayerScore();
            player.TakeDamage();
            CreateEnemyDeathExplosion();
            soundFX.ExplosionSound();
            Destroy(gameObject);
        }
    }

    private void CreateEnemyDeathExplosion()
    {
        Instantiate(deathExplosionPrefab, transform.position, Quaternion.identity);
    }
}
