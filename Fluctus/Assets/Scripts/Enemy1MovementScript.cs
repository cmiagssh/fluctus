using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1MovementScript : MonoBehaviour {
	void FixedUpdate () {
        RotatePlayer();
        MovePlayer();
        DestroyPlayer();
	}

    void RotatePlayer() {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.realtimeSinceStartup) * 40);
    }

    void MovePlayer() {
        transform.position += transform.right * Time.deltaTime;
    }

    void DestroyPlayer() {
        if (transform.position.x > 10.0f) {
            Destroy(gameObject);
        }
    }
}
