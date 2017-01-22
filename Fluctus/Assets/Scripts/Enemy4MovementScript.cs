using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4MovementScript : MonoBehaviour
{
    public string pointArrayTagName = "ShipPath";

    public float distanceToSkipToNextPoint = 0.3f;

    public GameObject nextPoint;
    public float speed = 1f;
    public Transform targetTransform;

    private Rigidbody2D rigidBody;
    public bool customPath = false;
    public GameObject[] pointArray;
    private int movingTowardsPoint = 0;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        LoadPathGameObjects();
    }

    void FixedUpdate()
    {
        GetNextPointPosition();
        LookAtClosestPlayer();
        MoveEnemyForward();
    }

    void LoadPathGameObjects()
    {
        if (!customPath)
        {
            pointArray = GameObject.FindGameObjectsWithTag(pointArrayTagName);
        }

        nextPoint = pointArray[0];
    }

    void GetNextPointPosition()
    {
        float distanceToActivePoint = Vector3.Distance(gameObject.transform.position, nextPoint.transform.position);

        if (distanceToActivePoint < distanceToSkipToNextPoint)
        {
            movingTowardsPoint++;

            if (movingTowardsPoint > (pointArray.Length - 1))
            {
                movingTowardsPoint = 0;
            }

            nextPoint = pointArray[movingTowardsPoint];
        }

        targetTransform = nextPoint.transform;
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
