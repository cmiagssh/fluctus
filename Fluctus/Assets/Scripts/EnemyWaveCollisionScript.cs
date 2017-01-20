using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveCollisionScript : MonoBehaviour {
    GameObject[] waves;

    // Use this for initialization
    void Start () {
        waves = GameObject.FindGameObjectsWithTag("Wave");
        Debug.Log("adsf");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.tag);

        if (coll.gameObject.tag == "WaveInnerCollider")
        {
            Debug.Log("Enter Inner Collision");
        }

        if (coll.gameObject.tag == "WaveOuterCollider")
        {
            Debug.Log("Enter Outer Collision");
        }
    }
}
