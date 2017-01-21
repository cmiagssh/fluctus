using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaveCollisionScript : MonoBehaviour {

    private Rigidbody2D rigidBody;

    public float knockBack;

    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if ((coll.gameObject.tag == "WaveOuterCollider") && (coll.gameObject.transform.parent.gameObject.GetComponent<WaveScript>().playerGameobject.tag != transform.tag))
        {
            //add iumpluse force away from origin of wave
            Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 waveOrigin = new Vector2(coll.transform.position.x, coll.transform.position.y);
            Vector2 impulseDirection = (playerPosition - waveOrigin);
            float impactDistance = impulseDirection.magnitude;
            float impactForce = 1/impactDistance;
            impulseDirection = impulseDirection.normalized;

            rigidBody.AddForce(impulseDirection * impactForce * knockBack, ForceMode2D.Impulse);

        }
    }
}
