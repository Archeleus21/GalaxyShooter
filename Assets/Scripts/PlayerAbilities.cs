using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;  //bullet game object
    [SerializeField] GameObject tripleShotPrefab;  //bullet game object

    [SerializeField] float fireRate = 1f;  //firespeed
    [SerializeField] float bulletSpeed = 5f;  //speed of bullet

    float speedBoost = 1.5f;
    bool canTripleShot = false;
    bool canSpeedBoost = false;

    float timer;  //used for shooting speed

    Player player;

    // Use this for initialization
    void Start ()
    {
        player = GetComponent<Player>();
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

            GameObject laserPrefabGO = Instantiate(laserPrefab, laserPosition, Quaternion.identity);
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

            GameObject tripleShotPrefabGO = Instantiate(tripleShotPrefab, tripleShotPosition, Quaternion.identity);
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
        StartCoroutine(StartSpeedBoostTimeLimit());
    }

    public IEnumerator StartTripleShotTimeLimit()
    {
        yield return new WaitForSeconds(5f);
        canTripleShot = false;
        print("end Tripleshot powerup");
    }

    public IEnumerator StartSpeedBoostTimeLimit()
    {
        yield return new WaitForSeconds(5f);
        canSpeedBoost = false;
        player.playerMovementSpeed = 10f;
        print("end Speed powerup");
    }
}
