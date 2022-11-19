using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExtendPaddleController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public Collider2D paddleKanan;
    public Collider2D paddleKiri;

    public float extension;
    public float duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            if (ball.GetComponent<BallController>().ballDir == -1)
            {
                paddleKanan.GetComponent<PaddleController>().ActivePUExtendPaddle(extension, duration);

            }
            else if (ball.GetComponent<BallController>().ballDir == 1)
            {
                paddleKiri.GetComponent<PaddleController>().ActivePUExtendPaddle(extension, duration);
            }

            Destroy(gameObject);
            manager.RemovePowerUp(gameObject);
        }
    }
}
