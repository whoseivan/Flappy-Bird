using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    public float forceX = 5;
    public float forceY = 3;
    Rigidbody2D rb;

    public delegate void onDied();
    public static event onDied died;

    void Start()
    {
        Input.simulateMouseWithTouches = true;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        }
        if (transform.position.y > 3.7f || transform.position.y < -2.8f)
        {
            lose();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lose();
    }

    void lose()
    {
        died?.Invoke();
        rb.Sleep();
    }
}