using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaveIntersectionDetectionScript : MonoBehaviour {
    public GameObject[] wavesArray;

    // Use this for initialization
    void Start ()
    {	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        wavesArray = GameObject.FindGameObjectsWithTag("Wave");
        if (wavesArray.Length >= 2)
        {
            for (int wave1 = 0; wave1 < wavesArray.Length; wave1++)
            {
                for (int wave2 = wave1 + 1; wave1 < wavesArray.Length; wave1++)
                {
                    Debug.Log("wave pair checked");
                }
            }
        }        
    }
}
