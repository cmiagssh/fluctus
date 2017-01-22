using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1MovementScript : MonoBehaviour {
    private bool direction = true;

	void FixedUpdate () {
        RotatePlayer();
        MovePlayer();
	}

    void RotatePlayer() {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.realtimeSinceStartup) * 40);
    }

    void MovePlayer() {
        if (direction)
        {
            transform.position += transform.right * Time.deltaTime;
        } else
        {
            transform.position -= transform.right * Time.deltaTime;
        }

        if (gameObject.transform.position.x > 23)
        {
            direction = false;
        }

        if (gameObject.transform.position.x < 8)
        {
            direction = true;
        }
    }
}
