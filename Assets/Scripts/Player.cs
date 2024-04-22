using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Vector2 _direction;

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
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + _direction * speed * Time.fixedDeltaTime);
    }
}
