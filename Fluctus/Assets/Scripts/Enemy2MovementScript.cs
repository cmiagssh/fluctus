using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2MovementScript : MonoBehaviour
{
    void FixedUpdate()
    {
        RotateEnemy();
        MoveEnemy();
    }

    void RotateEnemy()
    {
        transform.rotation = Quaternion.Euler(0, 0, Time.realtimeSinceStartup * -60);
    }

    void MoveEnemy()
    {
        transform.position += new Vector3(Mathf.Sin(Mathf.Deg2Rad * Time.realtimeSinceStartup * 60) * 0.04f, Mathf.Cos(Mathf.Deg2Rad * Time.realtimeSinceStartup * 60) * 0.04f, 0);
    }
}