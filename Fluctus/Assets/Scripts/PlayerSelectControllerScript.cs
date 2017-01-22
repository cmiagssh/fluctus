﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectControllerScript : MonoBehaviour {
	public GameObject[] p1Ships;
	public GameObject[] p2Ships;
	public GameObject p1IsReady;
	public GameObject p2IsReady;
    public GameObject playerPickInfoObject;
    private ShipPickInfoScript playerPick;

	private bool p1WasReset = true;
	private bool p2WasReset = true;
	private bool p1Ready = false;
	private bool p2Ready = false;
	private int  p1ShipIndex = 0;
	private int p2ShipIndex = 0;

	public float debug = 0f;


	// Use this for initialization
	void Start () {
        playerPick = playerPickInfoObject.GetComponent<ShipPickInfoScript>();
        GameObject[] musicArray = GameObject.FindGameObjectsWithTag("Music");
        foreach (GameObject music in musicArray)
        {
            Destroy(music);
        }	
	}
	
	// Update is called once per frame
	void Update () {
		debug = Input.GetAxis ("P1Roll");
		if (Input.GetAxis ("P1Roll") == 1 && p1WasReset && !p1Ready)
		{
			p1WasReset = !p1WasReset;
			p1Ships[p1ShipIndex].SetActive (false);
			p1ShipIndex++;
			p1ShipIndex = p1ShipIndex % p1Ships.Length;
			p1Ships[p1ShipIndex].SetActive (true);
		}
		if (Input.GetAxis ("P1Roll") == -1 && p1WasReset && !p1Ready)
		{
			p1WasReset = !p1WasReset;
			p1Ships [p1ShipIndex].SetActive (false);
			p1ShipIndex += p1Ships.Length-1;
			p1ShipIndex = p1ShipIndex % p1Ships.Length;
			p1Ships [p1ShipIndex].SetActive (true);
		}
		if (Input.GetAxis ("P1Roll") == 0 && !p1WasReset)
		{
			p1WasReset = !p1WasReset;
		}	
		if (Input.GetAxis ("P2Roll") == 1 && p2WasReset && !p2Ready)
		{
			p2WasReset = !p2WasReset;
			p2Ships[p2ShipIndex].SetActive (false);
			p2ShipIndex++;
			p2ShipIndex = p2ShipIndex % p2Ships.Length;
			p2Ships[p2ShipIndex].SetActive (true);
		}
		if (Input.GetAxis ("P2Roll") == -1 && p2WasReset && !p2Ready)
		{
			p2WasReset = !p2WasReset;
			p2Ships [p2ShipIndex].SetActive (false);
			p2ShipIndex += p2Ships.Length-1;
			p2ShipIndex = p2ShipIndex % p2Ships.Length;
			p2Ships [p2ShipIndex].SetActive (true);
		}
		if (Input.GetAxis ("P2Roll") == 0 && !p2WasReset)
		{
			p2WasReset= !p2WasReset;
		}
		if (Input.GetButtonDown ("P1Fire")) {
			p1Ready = true;
			p1IsReady.SetActive (true);
            playerPick.p1Pick = p1ShipIndex;
		}
		if (Input.GetButtonDown ("P2Fire")) {
			p2Ready = true;
			p2IsReady.SetActive (true);
            playerPick.p2Pick = p2ShipIndex;
        }
		if (p1Ready == true && p2Ready == true){
            //Neues Level kann hier geladen werden. Info des gepickten ships muss noch gespeichert werden -> siehe Dont destroy on load :)
            Application.LoadLevel(1);
		}
        if (Input.GetButtonDown("P1ButtonB") && p1Ready)
        {
            p1IsReady.SetActive(false);
            p1Ready = false;
        }
        if (Input.GetButtonDown("P2ButtonB") && p2Ready)
        {
            p2IsReady.SetActive(false);
            p2Ready = false;
        }

    }
}
