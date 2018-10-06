using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFX : MonoBehaviour
{
    Animator animator;
    //GameObject explosionPrefab;

    public int deathFXIndex;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        DeathExplosionFX();
	}

    public void DeathExplosionFX()
    {
        asdInstantiate(gameObject, transform.position, Quaternion.identity);
        animator.SetTrigger("Enemy Death");
        Destroy(gameObject, 2f);
    }
}
