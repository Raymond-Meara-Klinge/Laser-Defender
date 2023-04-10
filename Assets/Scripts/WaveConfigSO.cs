using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField]
    Transform pathPrefab;

    [SerializeField]
    float moveSpd = 5f;

    public Transform GetStartPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> points = new List<Transform>();
        foreach(Transform point in points)
        {
            points.Add(point);
        }
        return points;
    }

    public float GetMoveSpd()
    {
        return moveSpd;
    }
}
