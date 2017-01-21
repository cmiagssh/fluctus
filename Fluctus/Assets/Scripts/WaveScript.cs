using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour {

    private LineRenderer lineRenderer;
    private int circleSegments = 64;
    private Vector2 origin;
    private int frameCount = 0;

    public float radius = 5;
    public float width = 1;
    public float growthRatio = 1;
    public GameObject playerGameobject;
    
	// Use this for initialization
	void Start ()
    {
        origin = new Vector2(transform.position.x, transform.position.y);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.numPositions = circleSegments + 1;

        //tweak this to round corners
        lineRenderer.numCornerVertices = 10;

        lineRenderer.enabled = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        radius += growthRatio;
        drawCircle();
        if (frameCount > 1)
        {
            lineRenderer.enabled = true;
        }
        else
        {
            frameCount++;
        }
        
        //check despawn
        if (radius > 20f)
        {
            Destroy(gameObject);
        }
    }

    void drawCircle ()
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        //for all vertecies on circle
        for (int i = 0; i < circleSegments + 1; i++)
        {
            float angle = 2 * Mathf.PI / circleSegments * i;
            float x = origin.x + radius * Mathf.Cos(angle);
            float y = origin.y + radius * Mathf.Sin(angle);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}
