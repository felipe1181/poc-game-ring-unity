using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player player;
    private Animator animator;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //is moving
        if (player.direction.sqrMagnitude > 0)
        {
            animator.SetInteger("transition", 1);
        }
        else
        {
            animator.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }


        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(this.AttackSword());
        }
    }

    public IEnumerator AttackSword()
    {
        if (player.validAttack)
        {
            player.validAttack = false;
            animator.SetTrigger("attack");
            yield return new WaitForSeconds(1);
            player.validAttack = true;
        }

    }

    public void onAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, enemyLayer);
        if (hit != null)
        {
            hit.GetComponentInChildren<AnimationControl>().PlayOnHit();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(attackPoint.position, radius);
    }
    public void OnHit()
    {
        animator.SetTrigger("hit");
    }
}
