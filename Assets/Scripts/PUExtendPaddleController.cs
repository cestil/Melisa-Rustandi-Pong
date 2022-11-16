using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExtendPaddleController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public Rigidbody2D rigBall;
    public Collider2D paddleKanan;
    public Collider2D paddleKiri;
    public float extension;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            Destroy(gameObject);
            manager.RemovePowerUp(gameObject);
        }
    }
}
