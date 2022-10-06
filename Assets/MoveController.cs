using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float speed = 10f;
    private bool running = false;

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 direction = InputController.instance.direction;
        Vector3 dir = Vector3.zero;
        if(direction.z > 0)
        {
            dir += transform.forward;
        }
        if (direction.z < 0)
        {
            dir -= transform.forward;
        }
        if (direction.x > 0)
        {
            dir += transform.right;
        }
        if (direction.x < 0)
        {
            dir -= transform.right;
        }
        transform.position = Vector3.Lerp(transform.position, transform.position + dir, Time.fixedDeltaTime);
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
