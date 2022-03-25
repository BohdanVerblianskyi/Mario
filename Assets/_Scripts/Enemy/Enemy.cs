using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDestroyable
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _activationDistance;
    [SerializeField] private int _howManyScore;

    private GameObject _playerGO;
    private bool _canMove;
    private ContactPoint2D _contactPoint;

    private void Update()
    {
        ActivationMove();
        Move();
    }

    private void ActivationMove()
    {
        if (!_canMove && transform.position.x - _playerGO.transform.position.x < _activationDistance)
        {
            _canMove = true;
        }
    }

    private void Move()
    {
        if (_canMove)
        {
            _rigidbody2D.velocity = new Vector2(_moveSpeed, _rigidbody2D.velocity.y);
        }
    }

    public void SetWhoPlayer(in GameObject playerGO)
    {
        _playerGO = playerGO;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _contactPoint = collision.GetContact(0);
        if (_contactPoint.normal == Vector2.left || _contactPoint.normal == Vector2.right)
        {
            if (collision.gameObject.TryGetComponent<IDestroyable>(out IDestroyable destroyable))
            {
                destroyable.DestroyThisGO();
            }else
            {
                _moveSpeed = -_moveSpeed;
            }
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
        EventMeneger.SendAddScore(new Vector2(transform.position.x, transform.position.y), _howManyScore);
    }

    public void DestroyThisGO()
    {
        _animator.SetTrigger("Hit");
        EventMeneger.SendDiedEnemy();
        _audioSource.Play();
    }
}