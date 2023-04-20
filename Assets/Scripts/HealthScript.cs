using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    bool isPlayer;

    [SerializeField]
    int hp = 50;

    [SerializeField]
    int addPoints = 50;

    [SerializeField]
    ParticleSystem hitParts;

    [SerializeField]
    bool camShake;

    ShakeScreen shake;

    SFXPlayer sfx;

    ScoreKeep scoreKeep;

    LevelManager lvlMan;

    void Awake()
    {
        shake = Camera.main.GetComponent<ShakeScreen>();
        sfx = FindObjectOfType<SFXPlayer>();
        scoreKeep = FindObjectOfType<ScoreKeep>();
        lvlMan = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageScript damageDealer = other.GetComponent<DamageScript>();

        if (damageDealer != null)
        {
            DmgTaken(damageDealer.GetDmg());
            PlayFX();
            sfx.PlayHitClip();
            damageDealer.Strike();
        }
    }

    void DmgTaken(int v)
    {
        hp -= v;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!isPlayer)
        {
            scoreKeep.UpdateScore (addPoints);
        }
        else
        {
            lvlMan.LoadGO();
        }
        Destroy (gameObject);
    }

    public int GetHP()
    {
        return hp;
    }

    void PlayFX()
    {
        if (hitParts != null)
        {
            ParticleSystem instance =
                Instantiate(hitParts, transform.position, Quaternion.identity);
            Destroy(instance.gameObject,
            instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void CamShake()
    {
        if (shake != null && camShake == true)
        {
            shake.Play();
        }
    }
}
