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

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        length = GetComponent<Transform>();
    }

    private void Update()
    {
        MoveObject(GetInput());
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

    public void ActivePUExtendPaddle(float extension)
    {
        float x = length.localScale.x;
        float y = length.localScale.y;
        length.localScale = new Vector2(x, y * extension);
    }

    public void ActivePUPaddleSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }
}