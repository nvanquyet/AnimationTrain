using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController instance;
    [SerializeField] private MoveController moveController;
    [SerializeField] private AnimationController animtor;
    public Vector3 direction;
    public float horizontal;
    public float vertical;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        direction = Vector3.zero;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0, vertical);
        direction = direction.normalized;
        if((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) )
        {
            moveController.SetSpeed(10f);
            moveController.SetRunning(true);
            if(direction != Vector3.zero)
            {
                animtor.Run(true);
            }
        }
        else
        {
            moveController.SetSpeed(7.5f);
            moveController.SetRunning(false);
            animtor.Run(false);
        }
    }
}
