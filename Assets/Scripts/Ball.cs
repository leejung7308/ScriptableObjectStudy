using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public BallSO ballSO;
    public Rigidbody2D rb;
    private Vector2 direction;
    public VoidEventChannelSO gameStart;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        gameStart.OnEventRaised += BeginGamePlay;
    }
    private void OnDisable()
    {
        gameStart.OnEventRaised -= BeginGamePlay;
    }
    private void Update()
    {
        if(rb.velocity.magnitude <= 3f && direction != Vector2.zero)
        {
            rb.velocity = direction * 3f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball otherBall = collision.gameObject.GetComponent<Ball>();
        if (otherBall != null)
        {
            if (!ballSO.isWin(otherBall.ballSO))
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Bouncer"))
        {
            direction = Vector2.Reflect(direction, collision.GetContact(0).normal);
        }
    }
    private void BeginGamePlay()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    private void Bounce(Vector2 direction)
    {
        this.direction = Vector2.Reflect(this.direction, direction);
    }
}
