using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;  //bullet game object
    [SerializeField] GameObject tripleShotPrefab;  //bullet game object
    [SerializeField] GameObject playerShieldPrefab;


    [SerializeField] float fireRate = 1f;  //firespeed
    [SerializeField] float bulletSpeed = 5f;  //speed of bullet

    public bool isShieldActive = false;

    float speedBoost = 1.5f;
    float timer;  //used for shooting speed
    bool canTripleShot = false;
    bool canSpeedBoost = false;

    Animator animator;
    Player player;
    GameObject effectshandler;
    
    // Use this for initialization
    void Start ()
    {
        player = GetComponent<Player>();
        animator = gameObject.GetComponent<Animator>();
        effectshandler = GameObject.Find("Effects Handler");
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

	}


    //instantiates bullet
    public void ShootLaserBeam()
    {
        if(!canTripleShot)
        {
            LaserShot();
        }
        else
        {
            TripleShot();
        }
    }

    private void LaserShot()
    {
        if (timer > fireRate)
        {
            Vector3 laserPosition;
            laserPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

            timer = 0;

            GameObject laserPrefabGO = Instantiate(laserPrefab, laserPosition, Quaternion.identity, effectshandler.transform);
            Destroy(laserPrefabGO, .5f);
        }
    }

    private void TripleShot()
    {
        if (timer > fireRate)
        {
            timer = 0;

            //for (int i = -1; i < 2; i++)
            //{
            //    laserPosition = new Vector3(transform.position.x + (i * .25f), transform.position.y + 1, transform.position.z);

            //    GameObject laserPrefabGO = Instantiate(laserPrefab, laserPosition, Quaternion.identity, effectsHandler.transform);
            //    laserPrefabGO.GetComponent<Rigidbody>().AddForce(Vector3.up * bulletSpeed, ForceMode.Impulse);  //moves the laser
            //    Destroy(laserPrefabGO, .5f);
            //}

            Vector3 tripleShotPosition;
            tripleShotPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

            GameObject tripleShotPrefabGO = Instantiate(tripleShotPrefab, tripleShotPosition, Quaternion.identity, effectshandler.transform);
            Destroy(tripleShotPrefabGO, .5f);
        }
    }

    public void ActivateTripleShotPowerUp()
    {
        canTripleShot = true;
        StartCoroutine(StartTripleShotTimeLimit());
    }

    public void ActivateSpeedBoostPowerUp()
    {
        canSpeedBoost = true;
        player.playerMovementSpeed = player.playerMovementSpeed * speedBoost;

        if(player.playerMovementSpeed > 20f)
        {
            player.playerMovementSpeed = 20f;
        }

        StartCoroutine(StartSpeedBoostTimeLimit());
    }

    public void ActivateShield()
    {
        if (isShieldActive == true)
        {
            playerShieldPrefab.SetActive(true);
        }
        else
        {
            playerShieldPrefab.SetActive(false);
        }
    }

    public IEnumerator StartTripleShotTimeLimit()
    {
        yield return new WaitForSeconds(5f);
        canTripleShot = false;
    }

    public IEnumerator StartSpeedBoostTimeLimit()
    {
        yield return new WaitForSeconds(5f);
        canSpeedBoost = false;
        player.playerMovementSpeed = 10f;
    }

}
