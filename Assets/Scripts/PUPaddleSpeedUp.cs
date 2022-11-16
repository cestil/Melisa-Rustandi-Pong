using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSpeedUp : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public Collider2D paddleKanan;
    public Collider2D paddleKiri;
    public float magnitude;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            if (ball.GetComponent<Rigidbody2D>().velocity.normalized.x == (-1))
            {
                paddleKanan.GetComponent<PaddleController>().ActivePUPaddleSpeedUp(magnitude);
            }

            else if (ball.GetComponent<Rigidbody2D>().velocity.normalized.x == 1)
            {
                paddleKiri.GetComponent<PaddleController>().ActivePUPaddleSpeedUp(magnitude);
            }

            Destroy(gameObject);
            manager.RemovePowerUp(gameObject);
        }
    }
}
