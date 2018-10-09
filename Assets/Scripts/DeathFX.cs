using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFX : MonoBehaviour
{
    Animator animator;

    public int deathFXIndex;  //0 = enemyDeath, 1 = playerDeath

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

        switch(deathFXIndex)
        {
            case 0:
                animator.SetTrigger("Enemy Death");
                break;
            case 1:
                animator.SetTrigger("Player Death");
                break;
            default:
                print("No explosion");
                break;
        }
        
        Destroy(gameObject, 2f);
    }
}
