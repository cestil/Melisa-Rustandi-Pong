using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;

    private Rigidbody2D rig;

    private float totalMagnitude;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;

        totalMagnitude = 1;
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 1);
        Vector2 resetDir = -(rig.velocity.normalized);
        Vector2 velocityOnly = rig.velocity / (rig.velocity.normalized);
        Vector2 speedOnly = speed / (speed.normalized);

        rig.velocity = resetDir * (velocityOnly /= totalMagnitude);

        if ((velocityOnly.x < speedOnly.x) || (velocityOnly.y < speedOnly.y))
        {
            rig.velocity = resetDir * speedOnly;
        }

        totalMagnitude = 1;
    }

    public void ActivePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
        totalMagnitude *= magnitude;
    }
}