using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public Animator animator;
    public bool is_axe = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("swing") && is_axe)
        {
            animator.Play("swing");
        }
    }
}
