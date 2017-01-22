using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGridScript : MonoBehaviour {
    public GameObject particleSystem;

    private GameObject[,] particleSystemArray;
    private const int xElementSize = 100;
    private const int yElementSize = 60;
    private const int xmin = -10;
    private const int xmax = 20;
    private const int ymin = -6;
    private const int ymax = 10;

    // Use this for initialization
    void Start () {
        particleSystemArray = new GameObject[xElementSize, yElementSize];
        //screen duimensions
        for (int x = 0; x < 66; x++)
        {
            for (int y = 0; y < 42; y++)
            {
                //instantiate particlesystem from (-9,-5) to (9,5)
                float xPos = xmin + (((float)x / (float)xElementSize) * (xmax - xmin));
                float yPos = ymin + (((float)y / (float)yElementSize) * (ymax - ymin));
                GameObject newParticleSystem = Instantiate(particleSystem, new Vector3(xPos,yPos,0f), transform.rotation, transform);
            }
        }		
	}
}
