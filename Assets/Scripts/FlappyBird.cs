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
    public GameObject clickImg;
    public delegate void onDied();
    public static event onDied died;
    public delegate void onFly();
    public static event onFly fly;

    bool losed = false;
    bool firstTouch = false; // Используется для проверки первого нажатия

    void Start()
    {
        Input.simulateMouseWithTouches = true;
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false; // Отключаем физику в начале игры
    }

    void Update()
    {
        // Ждем первого нажатия для начала движения
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            if (!firstTouch)
            {
                clickImg.GetComponent<Animator>().Play("Waiting");
                firstTouch = true;
                rb.simulated = true; // Включаем физику
                rb.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse); // Начальное движение птицы                           
                clickImg.SetActive(false);
            }
            else
            {
                rb.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse); // Добавляем силу при каждом нажатии
            }
        }

        // Если птица выходит за пределы экрана
        if ((transform.position.y > 3.7f || transform.position.y < -2.8f) && !losed)
        {
            losed = true;
            lose();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!losed)
        {
            losed = true;
            lose();
        }
    }

    void lose()
    {
        died?.Invoke();
        GetComponent<SpriteRenderer>().sortingOrder = 1;
        forceX = 0f; // Останавливаем птицу при проигрыше
        forceY = 0f;
    }
}
