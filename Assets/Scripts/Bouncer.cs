using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public Vector2EventChannelSO ballCollided;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector3 direction = collision.GetContact(0).normal;
            ballCollided.RaiseEvent(-direction);
        }
    }
}
