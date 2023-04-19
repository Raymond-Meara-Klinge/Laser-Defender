using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [Header("Firing")]
    [SerializeField]
    AudioClip fireClip;

    [SerializeField]
    [Range(0f, 1f)]
    float fireVol = 1f;

    [Header("Hit")]
    [SerializeField]
    AudioClip hitClip;

    [SerializeField]
    [Range(0f, 1f)]
    float hitVol = 1f;

    public void PlayFireClip()
    {
        PlayClip(fireClip, fireVol);
    }
    public void PlayHitClip()
    {
        PlayClip(hitClip, hitVol);
    }

    void PlayClip(AudioClip clip, float vol)
    {
        Vector3 camPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, camPos, vol);
    }
}
