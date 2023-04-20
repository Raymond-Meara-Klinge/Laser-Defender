using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeep : MonoBehaviour
{
    int score = 0;

    static ScoreKeep instance;

    void Awake()
    {
        ManageSingle();
    }

    void ManageSingle()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy (gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad (gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void UpdateScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
    }

    public void ScoreReset()
    {
        score = 0;
    }
}
