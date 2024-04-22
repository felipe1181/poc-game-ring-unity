using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChestAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void openChest()
    {
        animator.SetTrigger("open");
        animator.SetInteger("transition", 1);
    }

    public void closeChest()
    {
        animator.SetInteger("transition", 2);
    }
}
