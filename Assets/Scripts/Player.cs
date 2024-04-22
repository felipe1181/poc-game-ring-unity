using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [Header("Stats")]
    public float totalHealth;
    public float currentHealth;
    public Image healthBar;
    public bool isDead;

    public float speed;
    private Vector2 _direction;


    public GameOverScreen gameOverScreen;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    private bool _validAttack = true;

    public bool validAttack
    {
        get { return _validAttack; }
        set { _validAttack = value; }
    }
    private new Rigidbody2D rigidbody2D;
    void Start()
    {
        currentHealth = totalHealth;
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (isDead == false)
        {
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

    }

    private void FixedUpdate()
    {
        if (isDead == false)
        {
            rigidbody2D.MovePosition(rigidbody2D.position + _direction * speed * Time.fixedDeltaTime);
        }
    }


}
