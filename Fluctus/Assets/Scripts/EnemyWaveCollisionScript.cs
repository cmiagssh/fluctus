using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveCollisionScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.collider.gameObject);

        if (coll.collider.gameObject.tag == "WaveInnerCollider")
        {
            Debug.Log("Enter Inner Collision");
        }

        if (coll.collider.gameObject.tag == "WaveOuterCollider")
        {
            Debug.Log("Enter Outer Collision");
        }
    }
}