using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollisionScript : MonoBehaviour
{
    CircleCollider2D circleCollider;

    public float waveStartRadius = 1.0f;
    public float offset; //Adjust for pefect match of collider and linerenderer

    private float widthOffset;

    void Start()
    {

        circleCollider = GetComponent<CircleCollider2D>();

        circleCollider.radius = 0f;

        if (transform.tag == "WaveInnerCollider")
        {
            widthOffset = -(transform.parent.GetComponent<DrawCircle>().width / 2);
        } else if (transform.tag == "WaveOuterCollider")
        {
            widthOffset = transform.parent.GetComponent<DrawCircle>().width / 2;
        }
    }

    void FixedUpdate()
    {
        if (circleCollider.radius <= 0f) {
            circleCollider.radius = 0;
        } else
        {
            if (transform.tag == "WaveInnerCollider")
            {
                widthOffset = -(transform.parent.GetComponent<DrawCircle>().width / 2);
            }
            else if (transform.tag == "WaveOuterCollider")
            {
                widthOffset = transform.parent.GetComponent<DrawCircle>().width / 2;
            }

            circleCollider.radius = transform.parent.GetComponent<DrawCircle>().radius + widthOffset + offset;
        }
    }
}
