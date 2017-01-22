using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsControllerScript : MonoBehaviour {

	public GameObject startMenuControllerScript;

	void Update()
	{

		if (Input.GetButtonDown ("P1ButtonX") || Input.GetButtonDown ("P2ButtonX")) {
			startMenuControllerScript.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}