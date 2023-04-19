using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpd = 5f;

    [SerializeField]
    float padLeft;

    [SerializeField]
    float padRight;

    [SerializeField]
    float padTop;

    [SerializeField]
    float padBottom;

    Vector2 putin;

    Vector2 MinBound;

    Vector2 MaxBound;
    Firing fired;

    void Awake()
    {
        fired = GetComponent<Firing>();
    }

    void Start()
    {
        InitBound();
    }

    void Update()
    {
        Move();
    }

    void InitBound()
    {
        Camera mainCam = Camera.main;
        MinBound = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        MaxBound = mainCam.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        Vector2 delta = putin * moveSpd * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x =
            Mathf
                .Clamp(transform.position.x + delta.x,
                MinBound.x + padLeft,
                MaxBound.x - padRight);
        newPos.y =
            Mathf
                .Clamp(transform.position.y + delta.y,
                MinBound.y + padBottom,
                MaxBound.y - padTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        putin = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (fired != null)
        {
            fired.isFired = value.isPressed;
        }
    }
}
