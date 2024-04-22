using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;
    private Skeleton skeleton;
    private PlayerAnimation player;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerAnimation>();
        skeleton = GetComponentInParent<Skeleton>();
    }


    public void PlayAnimation(int value)
    {
        animator.SetInteger("transition", value);
    }
    public void PlayAnimationAttack()
    {
        animator.SetTrigger("attack");
    }

    public void PlayOnHit()
    {
        if (skeleton.currentHealth <= 0)
        {
            skeleton.isDead = true;
            animator.SetTrigger("death");
            Destroy(skeleton.gameObject, 1f);
        }
        else
        {
            skeleton.currentHealth = skeleton.currentHealth - 50;
            skeleton.healthBar.fillAmount = skeleton.currentHealth / skeleton.totalHealth;
            animator.SetTrigger("hit");
        }
    }

    public void Attack()
    {
        if (skeleton.isDead == false)
        {
            Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);
            if (hit != null)
            {
                player.OnHit();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(attackPoint.position, radius);
    }
}
