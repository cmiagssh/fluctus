using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveCollisionScript : MonoBehaviour
{
    int nrColliders = 0;
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "WaveInnerCollider")
        {
            nrColliders--;
        }

        if (coll.gameObject.tag == "WaveOuterCollider")
        {
            nrColliders++;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "WaveOuterCollider")
        {
            nrColliders--;
        }

        if (coll.gameObject.tag == "WaveInnerCollider")
        {
            nrColliders++;
        }
    }

    void FixedUpdate()
    {
        if (nrColliders >= 2) {
            animator.SetBool("Alive", false);
            audioSource.Play();
            Destroy(gameObject, 5/8f);
        }
    }
}
