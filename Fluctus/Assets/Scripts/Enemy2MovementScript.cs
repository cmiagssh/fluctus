﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2MovementScript : MonoBehaviour {
<<<<<<< HEAD
    public GameObject closestPlayer;

    public float speed = 1000000000000.0f;

    public Transform Target;

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;
=======
    GameObject closestPlayer;
>>>>>>> 6cf131f8a596d41bb4ed28b29115f65a1a85cc1e

    void FixedUpdate()
    {
        GetClosestPlayerPosition();
        RotateEnemy();
        MoveEnemy();
        DestroyEnemy();
    }

    void GetClosestPlayerPosition() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player1");
        GameObject player1 = players[0];

        players = GameObject.FindGameObjectsWithTag("Player2");
        GameObject player2 = players[0];

        if (
            Vector3.Distance(player1.transform.position, gameObject.transform.position) <
            Vector3.Distance(player2.transform.position, gameObject.transform.position)
        )
        {
            closestPlayer = player1;
        }
        else {
            closestPlayer = player2;
        }

<<<<<<< HEAD
        Target = closestPlayer.transform;
    }

    void RotateEnemy()
    {
        //find the vector pointing from our position to the target
        _direction = (Target.position - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        _lookRotation = Quaternion.LookRotation(_direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime);

        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
=======
        Debug.Log(closestPlayer);
    }

    void RotateEnemy()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.realtimeSinceStartup) * 40);
>>>>>>> 6cf131f8a596d41bb4ed28b29115f65a1a85cc1e
    }

    void MoveEnemy()
    {
        transform.position += transform.right * Time.deltaTime;
    }

    void DestroyEnemy()
    {
<<<<<<< HEAD

=======
        if (transform.position.x > 10.0f)
        {
            Destroy(gameObject);
        }
>>>>>>> 6cf131f8a596d41bb4ed28b29115f65a1a85cc1e
    }
}

