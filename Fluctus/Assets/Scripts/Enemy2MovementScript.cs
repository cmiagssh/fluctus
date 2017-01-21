using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2MovementScript : MonoBehaviour {
    GameObject closestPlayer;

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

        Debug.Log(closestPlayer);
    }

    void RotateEnemy()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.realtimeSinceStartup) * 40);
    }

    void MoveEnemy()
    {
        transform.position += transform.right * Time.deltaTime;
    }

    void DestroyEnemy()
    {
        if (transform.position.x > 10.0f)
        {
            Destroy(gameObject);
        }
    }
}

