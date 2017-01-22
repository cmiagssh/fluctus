using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToNextLevel : MonoBehaviour {
    public int jumpToScene = 2;
    private GameObject[] enemyArray;
	
	// Update is called once per frame
	void FixedUpdate () {
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyArray.Length == 0) {
            Application.LoadLevel(jumpToScene);
        }
    }
}
