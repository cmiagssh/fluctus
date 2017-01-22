using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenScript : MonoBehaviour
{
    private GameObject[] infosArray;

    public GameObject entities;
	// Update is called once per frame
    void Start()
    {
        infosArray = GameObject.FindGameObjectsWithTag("Info");
        foreach (GameObject Info in infosArray)
        {
            Destroy(Info);
        }
    }

	void Update () {
        if (Input.GetButtonDown("P1Fire") || Input.GetButtonDown("P2Fire"))
        {
            Application.LoadLevel(0);
            entities.SetActive(false);
       }           
    }
}
