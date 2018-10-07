using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject deathExplosionPrefab;
    [SerializeField] float enemyMovementSpeed = 2f;

    // Use this for initialization
    void Start ()
    {
        
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
            CreateEnemyDeathExplosion();
            Destroy(otherObj.gameObject);
            Destroy(gameObject);
        }
        else if(otherObj.name == "Player")
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
            CreateEnemyDeathExplosion();
            Destroy(gameObject);
        }
        else
        {
            player.TakeDamage();
            CreateEnemyDeathExplosion();
            Destroy(gameObject);
        }
    }

    private void CreateEnemyDeathExplosion()
    {
        Instantiate(deathExplosionPrefab, transform.position, Quaternion.identity);
    }
}
