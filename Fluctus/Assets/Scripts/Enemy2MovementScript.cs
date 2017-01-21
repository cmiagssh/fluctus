using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2MovementScript : MonoBehaviour {
    public GameObject closestPlayer;

    public float speed = 1000000000000.0f;

    public Transform Target;

    //values for internal use
    private Quaternion targetRotation;
    private Vector2 lookDirection;
    private float atan2;
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();
    }

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

        Target = closestPlayer.transform;
    }

    void RotateEnemy()
    {
        //transform.forward = 

        /*
        //find the vector pointing from our position to the target
        lookDirection = (new Vector2(Target.position.x, Target.position.y) - new Vector2(transform.position.x, transform.position.x));
        //calculate rotation using inverse tanget function
        atan2 = Mathf.Atan2(lookDirection.y, lookDirection.x);
        //rotate us over time according to speed until we are in the required rotation
        targetRotation = Quaternion.Euler(0f,0f,atan2 * Mathf.Rad2Deg); //perfect rotation facing nearest player
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        transform.rotation = targetRotation;
        */

    }

    void MoveEnemy()
    {
        Debug.Log(transform.position.ToString() + " " + transform.right.ToString());
        rigidBody.MovePosition(transform.position + transform.right * speed);
        
    }

    void DestroyEnemy()
    {
        if (transform.position.x > 10.0f)
        {
            Destroy(gameObject);
        }
    }
}