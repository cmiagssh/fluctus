using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollisionScript : MonoBehaviour
{
    public float grothRatio = 0.01f;
    CircleCollider2D circleCollider;

    public float waveStartRadius = 1.0f;

    public float deleteWhenBiggerThan = 10.0f;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();

        circleCollider.radius = waveStartRadius;
    }

    void FixedUpdate()
    {
        circleCollider.radius += this.grothRatio;

        if (circleCollider.radius > deleteWhenBiggerThan)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
