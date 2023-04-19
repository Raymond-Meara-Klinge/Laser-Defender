using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeep : MonoBehaviour
{
    int score = 0;

    public int GetScore()
    {
        return score;
    }

    public void UpdateScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }

    public void ScoreReset()
    {
        score = 0;
    }
}
