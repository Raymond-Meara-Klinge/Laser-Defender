using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField]
    List<GameObject> eneFabs;

    [SerializeField]
    Transform pathPrefab;

    [SerializeField]
    float moveSpd = 5f;

    [SerializeField]
    float eneSpawnTime = 1f;

    [SerializeField]
    float spawnVariance = 0f;

    [SerializeField]
    float minSpawnTime = 2f;

    public Transform GetStartPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> points = new List<Transform>();
        foreach (Transform pathPoint in pathPrefab)
        {
            points.Add (pathPoint);
        }
        return points;
    }

    public float GetMoveSpd()
    {
        return moveSpd;
    }

    public GameObject GetEnemFabs(int index)
    {
        return eneFabs[index];
    }

    public int GetEnemCount()
    {
        return eneFabs.Count;
    }

    public float GetSpawnTime()
    {
        float spawnTime =
            Random
                .Range(eneSpawnTime - spawnVariance,
                eneSpawnTime + spawnVariance);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }
}
