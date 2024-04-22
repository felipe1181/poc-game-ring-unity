using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Skeleton : MonoBehaviour
{
    [Header("Stats")]
    public float totalHealth;
    public float currentHealth;
    public Image healthBar;
    public bool isDead;

    [Header("Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimationControl animationControl;

    private Player player;
    public int attackCooldown = 2; // Seconds between attacks
    private float attackCooldownLeft; // Seconds left until this object can attack again

    private Vector2 tempRotation;


    void Start()
    {
        currentHealth = totalHealth;
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        tempRotation = transform.eulerAngles;
    }

    void Update()
    {
        if (isDead == false)
        {
            agent.SetDestination(player.transform.position);
            attackCooldownLeft -= Time.deltaTime;
            if (Vector2.Distance(transform.position, player.transform.position) - agent.stoppingDistance <= 1)
            {
                if (attackCooldownLeft <= 0f)
                {
                    attackCooldownLeft = attackCooldown;
                    animationControl.PlayAnimationAttack();
                }
                else
                {

                    animationControl.PlayAnimation(0);
                }

            }
            else
            {
                animationControl.PlayAnimation(3);
            }

            float positionPlayerAndEnemyDiff = player.transform.position.x - transform.position.x;
            bool isRightPosition = positionPlayerAndEnemyDiff > 0;

            if (isRightPosition)
            {

                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }

    }

}
