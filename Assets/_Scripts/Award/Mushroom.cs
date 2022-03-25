using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour , IEdible
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _howManyScore;

    private bool _canMove;
    private ContactPoint2D _contactPoint;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_canMove)
        {
            _rigidbody2D.velocity = new Vector2(_moveSpeed, _rigidbody2D.velocity.y);
        }
    }

    public void CanMove()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _canMove = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _contactPoint = collision.GetContact(0);
        if (_contactPoint.normal == Vector2.left || _contactPoint.normal == Vector2.right)
        {
            _moveSpeed = -_moveSpeed; 
        }
    }

    public void DestroyThisGO()
    {
        EventMeneger.SendAddScore(transform.position, _howManyScore);
        Destroy(gameObject);
    }
}
