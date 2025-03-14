using System;
using UnityEngine;

public class ObjectMovementAlongCurve : MonoBehaviour
{
    public Transform[] controlPoints;
    public GameObject objectToMove;
    public float speed = 1.0f;
    public float t = 0.0f;

     void Awake()
    {
        t = 0.0f;
    }

    void Update()
    {
        MoveObjectAlongCurve();
    }

    void MoveObjectAlongCurve()
    {
        if (t <= 1.0f)
        {
            Vector2 position = CalculateBezierPoint(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position);
            objectToMove.transform.position = position;
            t += Time.deltaTime * speed;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    Vector2 CalculateBezierPoint(float t, Vector2 p0, Vector2 p1, Vector2 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector2 point = uu * p0;
        point += 2 * u * t * p1;
        point += tt * p2;

        return point;
    }
}