using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour {

    private LineRenderer lineRenderer;
    private int circleSegments = 1024;

    public float radius = 5;
    public float width = 1;
    public Vector2 origin;

	// Use this for initialization
	void Start ()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.numPositions = circleSegments + 1;

        //tweak this to round corners
        lineRenderer.numCornerVertices = 10;

    }
	
	// Update is called once per frame
	void Update ()
    {
        drawCircle();
    }

    void drawCircle ()
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        //for all vertecies on circle
        for (int i = 0; i <= circleSegments + 1; i++)
        {
            float angle = 2 * Mathf.PI / circleSegments * i;
            float x = origin.x + radius * Mathf.Cos(angle);
            float y = origin.y + radius * Mathf.Sin(angle);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}
