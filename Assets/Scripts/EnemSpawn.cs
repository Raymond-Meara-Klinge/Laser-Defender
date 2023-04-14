using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemSpawn : MonoBehaviour
{
    [SerializeField]
    List<WaveConfigSO> configs;

    [SerializeField]
    float waveSpd = 0f;

    WaveConfigSO curWav;

    [SerializeField]
    bool isLoop;

    void Start()
    {
        StartCoroutine(SpawnEnemWaves());
    }

    IEnumerator SpawnEnemWaves()
    {
        foreach (WaveConfigSO wave in configs)
        {
            do
            {
                curWav = wave;
                for (int i = 0; i < curWav.GetEnemCount(); i++)
                {
                    Instantiate(curWav.GetEnemFabs(i),
                    curWav.GetStartPoint().position,
                    Quaternion.identity,
                    transform);
                    yield return new WaitForSeconds(curWav.GetSpawnTime());
                }
                yield return new WaitForSeconds(waveSpd);
            }
            while (isLoop);
        }
    }

    public WaveConfigSO GetCurWav()
    {
        return curWav;
    }
}
