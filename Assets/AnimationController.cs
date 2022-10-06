using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(animator == null)
        {
            return;
        }
        animator.SetFloat("Horizontal", InputController.instance.direction.x, 1f, Time.fixedDeltaTime * 5);
        animator.SetFloat("Vertical", InputController.instance.direction.z, 1f, Time.fixedDeltaTime * 5);
    }

    public void Run(bool condition)
    {
        animator.SetBool("Run", condition);
    }
}
