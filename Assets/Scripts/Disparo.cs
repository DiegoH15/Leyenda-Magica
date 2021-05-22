using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparo : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public float timer;
    public float maxTimer;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Timer();
    }
    void Move()
    {
        rb2d.velocity = new Vector2(0, speed);
    }
    void Timer()
    {
        timer = timer + Time.deltaTime;
        if (timer >= maxTimer)
        {
            Destroy(gameObject);
        }
    }

}
