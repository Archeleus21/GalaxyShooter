using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;  //bullet game object
    [SerializeField] float fireRate = 1f;  //firespeed
    [SerializeField] float bulletSpeed = 5f;  //speed of bullet

    float timer;  //used for shooting speed

    GameObject effectsHandler;

	// Use this for initialization
	void Start ()
    {
        effectsHandler = GameObject.Find("Effects Handler");  //finds in heirarchy
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
		
	}


    //instantiates bullet
    public void ShootLaserBeam()
    {
        Vector3 laserPosition;

        laserPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        if (timer > fireRate)
        {
            timer = 0;
            GameObject laserPrefabGO = Instantiate(laserPrefab, laserPosition, Quaternion.identity, effectsHandler.transform);
            laserPrefabGO.GetComponent<Rigidbody>().AddForce(Vector3.up * bulletSpeed, ForceMode.Impulse);  //moves the laser
            Destroy(laserPrefabGO, .75f);

        }

    }
}
