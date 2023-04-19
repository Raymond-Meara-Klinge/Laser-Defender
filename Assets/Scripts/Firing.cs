using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    [Header("General")]
    [SerializeField]
    GameObject projPrefab;

    [SerializeField]
    float projSpd = 20f;

    [SerializeField]
    float projLife = 5f;

    [SerializeField]
    float bRateOfFire = .2f;

    [Header("AI")]
    [SerializeField]
    float rateVary = 0f;

    [SerializeField]
    float minRate = .1f;

    [SerializeField]
    bool fireAI;

    [HideInInspector]
    public bool isFired;

    Coroutine fireRoutine;

    SFXPlayer sfx;

    void Awake()
    {
        sfx = FindObjectOfType<SFXPlayer>();
    }

    void Start()
    {
        if (fireAI)
        {
            isFired = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFired && fireRoutine == null)
        {
            fireRoutine = StartCoroutine(FireConstantly());
        }
        else if (!isFired && fireRoutine != null)
        {
            StopCoroutine (fireRoutine);
            fireRoutine = null;
        }
    }

    IEnumerator FireConstantly()
    {
        while (true)
        {
            GameObject instance =
                Instantiate(projPrefab,
                transform.position,
                Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projSpd;
            }
            Destroy (instance, projLife);

            float nextProj =
                UnityEngine
                    .Random
                    .Range(bRateOfFire - rateVary, bRateOfFire + rateVary);
            nextProj = Mathf.Clamp(nextProj, minRate, float.MaxValue);
            sfx.PlayFireClip();

            yield return new WaitForSeconds(nextProj);
        }
    }
}
