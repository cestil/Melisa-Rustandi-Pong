using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;

    private Transform length;

    private bool extend;
    public float extendDuration;
    private float timerExtend;
    private float totalExtendPU;

    public bool speedUp;
    public float speedUpDuration;
    public float timerSpeedUp;
    public float totalSpeedUp;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        length = GetComponent<Transform>();

        extend = false;
        totalExtendPU = 1;
        timerExtend = 0;

        speedUp = false;
        totalSpeedUp = 1;
        timerSpeedUp = 0;
    }

    private void Update()
    {
        MoveObject(GetInput());

        if (extend == true)
        {
            timerExtend += Time.deltaTime;

            if (timerExtend >= extendDuration)
            {
                DeactivePUExtendPaddle();
            }
        }

        if (speedUp == true)
        {
            timerSpeedUp += Time.deltaTime;

            if (timerSpeedUp >= speedUpDuration)
            {
                DeactivePUExtendPaddle();
            }
        }
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            if (gameObject.transform.position.y < 3.67759f)
            {
                return Vector2.up * speed;
            }
        }
        else if (Input.GetKey(downKey))
        {
            if (gameObject.transform.position.y > -3.67759f)
            {
                return Vector2.down * speed;
            }
        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        Debug.Log("TEST: " + movement);
        rig.velocity = movement;
    }

    public void ActivePUExtendPaddle(float extension, float duration)
    {
        timerExtend = 0;
        length.localScale = new Vector2(length.localScale.x, length.localScale.y * extension);
        extendDuration = duration;
        extend = true;
        totalExtendPU *= extension;
    }

    public void DeactivePUExtendPaddle()
    {
        length.localScale = new Vector2(length.localScale.x, length.localScale.y / totalExtendPU);
        extend = false;
        timerExtend = 0;
        totalExtendPU = 1;
    }

    public void ActivePUPaddleSpeedUp(float magnitude, float duration)
    {
        rig.velocity *= magnitude;
        speedUpDuration = duration;
        speedUp = true;
        totalSpeedUp *= magnitude;
    }

    public void DeactivePUSpeedUpPaddle()
    {
        rig.velocity /= totalSpeedUp;
        speedUp = false;
        timerSpeedUp = 0;
        totalSpeedUp = 1;
    }
}