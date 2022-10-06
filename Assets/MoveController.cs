using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float speed = 7.5f;
    private bool running = false;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(InputController.instance.direction * speed * Time.deltaTime, Space.World);
    }

    public void SetRunning(bool codition)
    {
        running = codition;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public bool GetRunning()
    {
        return running;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
