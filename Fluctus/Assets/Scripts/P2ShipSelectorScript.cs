using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2ShipSelectorScript : MonoBehaviour {
    public GameObject[] shipsArray = new GameObject[4];
    private GameObject[] infosArray;
    private GameObject info;


    // Use this for initialization
    void Start()
    {
        infosArray = GameObject.FindGameObjectsWithTag("Info");
        info = infosArray[0];
        shipsArray[info.GetComponent<ShipPickInfoScript>().p2Pick].SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
