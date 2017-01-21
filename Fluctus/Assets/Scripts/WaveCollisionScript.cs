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

        circleCollider.radius = 0f;
    }

    void FixedUpdate()
    {
        if (circleCollider.radius <= 0.2f) {
            circleCollider.radius = waveStartRadius;
        }

        circleCollider.radius += this.grothRatio;

        if (circleCollider.radius > deleteWhenBiggerThan)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
