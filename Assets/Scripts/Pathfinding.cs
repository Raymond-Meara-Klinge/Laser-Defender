using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField]
    WaveConfigSO waveCon;

    List<Transform> points;

    int pointIndex = 0;

    void Start()
    {
        points = waveCon.GetWayPoints();
        transform.position = points[pointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (pointIndex < points.Count)
        {
            Vector3 targPos = points[pointIndex].position;
            float delta = waveCon.GetMoveSpd() * Time.deltaTime;
            transform.position =
                Vector2.MoveTowards(transform.position, targPos, delta);
            if (transform.position == targPos)
            {
                pointIndex++;
            }
        }
        else
        {
            Destroy (gameObject);
        }
    }
}
