using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour {

    public int nrColliders = 0;
    public int collisionCount = 0;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        //CheckIfActivated();
        ScanWaveCollisions();

    }

    void CheckIfActivated()
    {
        if (nrColliders >= 2)
        {
            gameObject.GetComponent<ParticleSystem>().enableEmission = true;
        }
        else
        {
            gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }

    void ScanWaveCollisions()
    {
        GameObject[] wavesArray = GameObject.FindGameObjectsWithTag("Wave");
        //collisionCount = 0;

        foreach (GameObject wave in wavesArray)
        {
            WaveScript waveScript = wave.GetComponent<WaveScript>();
            float distance = (transform.position - wave.transform.position).magnitude;
            float minDist = waveScript.radius - waveScript.width /2f;
            float maxDist = waveScript.radius + waveScript.width / 2f;
            if ((distance >= minDist) && (distance <= maxDist))
            {
                collisionCount++;
                Debug.Break();
            }           
        }

        if (collisionCount >= 2)
        {
            ParticleSystem.EmissionModule em = gameObject.GetComponent<ParticleSystem>().emission;
            em.enabled = true;
            //gameObject.GetComponent<ParticleSystem>().emission.enabled = true;
        }
        else
        {
            //gameObject.GetComponent<ParticleSystem>().emission.enabled = false;
            ParticleSystem.EmissionModule em = gameObject.GetComponent<ParticleSystem>().emission;
            Debug.Log("Diable emission");
            em.enabled = false;
        }
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
}
