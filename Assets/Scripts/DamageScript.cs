using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] public int dmg = 10;

    public int GetDmg()
    {
        return dmg;
    }

    public void Strike()
    {
        Destroy(gameObject);
    }
}
