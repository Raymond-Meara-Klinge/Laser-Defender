using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    Slider hpSlider;

    [SerializeField]
    HealthScript playerHP;

    [Header("Score")]
    [SerializeField]
    TextMeshProUGUI scored;

    ScoreKeep score;

    void Awake()
    {
        score = FindObjectOfType<ScoreKeep>();
    }

    void Start()
    {
        hpSlider.maxValue = playerHP.GetHP();
    }

    void Update()
    {
        hpSlider.value = playerHP.GetHP();
        scored.text = score.GetScore().ToString("000000");
    }
}
