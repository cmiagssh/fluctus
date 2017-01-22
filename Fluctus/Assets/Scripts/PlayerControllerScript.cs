using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private GameObject newWavePrefab;

    public GameObject wavePrefab;
    public string rollInput;
    public string thrustInput;
    public string fireInput;
    public float thrust;
    public float mass;
    public float angularDrag;
    public float linearDrag;
    public float rollForce;
    public float thrustForce;
    public float pulseWidth;

    float lastShooted = 0f;

    public string playerColour;

	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.angularDrag = angularDrag;
        rigidBody.drag = linearDrag;
        rigidBody.mass = mass;
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        var roll = Input.GetAxis(rollInput);
        thrust = Input.GetAxis(thrustInput);
        //Vector3 direction = new Vector3(x, y, 0).normalized;
        //transform.position += direction * speed * Time.deltaTime;

        //thust
        rigidBody.AddForce(transform.up * thrust * thrustForce);
        rigidBody.angularVelocity -= (roll * rollForce);

        //torque

        if (Input.GetButtonDown(fireInput) && (Time.realtimeSinceStartup - lastShooted > 0.8f))
        {
            lastShooted = Time.realtimeSinceStartup;

            newWavePrefab = Instantiate(wavePrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            newWavePrefab.GetComponent<WaveScript>().playerGameobject = gameObject;
            newWavePrefab.GetComponent<WaveScript>().width = pulseWidth;
        }
    }
}
