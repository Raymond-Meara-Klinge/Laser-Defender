using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIOvered : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI score;

    ScoreKeep scoreKeep;

    void Awake()
    {
        scoreKeep = FindObjectOfType<ScoreKeep>();
    }

    void Start()
    {
        score.text = scoreKeep.GetScore().ToString("00000000");
    }
}
