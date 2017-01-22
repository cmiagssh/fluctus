using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3MovementScript : MonoBehaviour {
    public GameObject closestPlayer;
    public float speed = 1f;
    public Transform targetTransform;

    private Rigidbody2D rigidBody;

	void Start () {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();		
	}

    void FixedUpdate()
    {
        GetClosestPlayerPosition();
        LookAtClosestPlayer();
        MoveEnemyForward();
    }

    void GetClosestPlayerPosition()
    {
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
        else
        {
            closestPlayer = player2;
        }

        targetTransform = closestPlayer.transform;
    }

    void LookAtClosestPlayer()
    {
        Vector3 diff = targetTransform.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    void MoveEnemyForward()
    {
        //rigidBody.MovePosition(new Vector2(transform.position.x, transform.position.y) + new Vector2(1,0) * Time.deltaTime);
        rigidBody.AddRelativeForce(Vector2.up * 10, ForceMode2D.Force);
    }
}
