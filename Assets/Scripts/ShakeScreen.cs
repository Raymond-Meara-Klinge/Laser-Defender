using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreen : MonoBehaviour
{
    [SerializeField]
    float shakeDur = 1f;

    [SerializeField]
    float shakeMag = .5f;

    Vector3 initPos;

    void Start()
    {
        initPos = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapTime = 0;
        while (elapTime < shakeDur)
        {
            transform.position =
                initPos +
                (Vector3) UnityEngine.Random.insideUnitCircle * shakeMag;
                elapTime +=Time.deltaTime;
                yield return new WaitForEndOfFrame();
        }
        transform.position = initPos;
    }
}
