using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieScript : MonoBehaviour {
    private Animator animator;
    public GameObject deathScreen;

    void Start ()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Arena")
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("Alive", false);
        Destroy(gameObject, (5 / 10f));
        deathScreen.SetActive (true);
      
    }
}
