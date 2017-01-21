using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuControllerScript : MonoBehaviour {
	public GameObject creditsScreen;
	public GameObject playerSelectScreen;

	void Update()
	{
		if (Input.GetButtonDown("P1Fire") || Input.GetButtonDown("P2Fire"))
		{
			playerSelectScreen.SetActive(true);
			gameObject.SetActive (false);
		}
		if (Input.GetButtonDown ("P1ButtonX") || Input.GetButtonDown ("P2ButtonX")) {
			creditsScreen.SetActive (true);
			gameObject.SetActive (false);
		}

		if (Input.GetButtonDown("P1ButtonB") || Input.GetButtonDown("P2ButtonB"))
		{
			Application.Quit ();	
		}

	}
		
}
