using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public float magnitude;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            Vector2 velocityOnly = ball.GetComponent<Rigidbody2D>().velocity.normalized;
            if ((velocityOnly.x >= 40) || (velocityOnly.y >= 40))
            {
                return;
            }
            else
            {
                ball.GetComponent<BallController>().ActivePUSpeedUp(magnitude);
            }

            Destroy(gameObject);
            manager.RemovePowerUp(gameObject);
        }
    }
}