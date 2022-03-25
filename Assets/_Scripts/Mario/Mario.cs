using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour, IDestroyable
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioJump;
    [SerializeField] private AudioClip _audioEatMashroom;
    [SerializeField] private AudioClip _audioDiad;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpHight;
    [SerializeField] private float _gravityScale;

    private float _startJumpPositionY;
    private ContactPoint2D _contactPoint;
    private Vector2 _pastPosition;
    private bool _isUpCollision;
    private bool _isDownCollision;
    private bool _isLeftCollision;
    private bool _isRightCollision;
    private bool _isJump;
    private bool _isAttack;
    private bool _isWatchRight;
    private bool _isLevelUp;

    public bool IsDownCollision { get => _isDownCollision;}

    private void Start()
    {
        _pastPosition = new Vector2(transform.position.x, transform.position.y);
        _rigidbody2D.gravityScale = _gravityScale;
        _isWatchRight = true;
        _isDownCollision = true;
    }

    private void Update()
    {
        ToJump();
        ChachFlip();
    }

    private void FixedUpdate()
    {
        Move();
        ActionWhileDriving();
    }

    private void ActionWhileDriving()
    {
        if (_pastPosition != new Vector2(transform.position.x, transform.position.y))
        {
            _isUpCollision = false;
            _isRightCollision = false;
            _isDownCollision = false;
            _isLeftCollision = false;
        }
        _pastPosition = new Vector2(transform.position.x, transform.position.y);
    }

    private void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
    }

    private void ToJump()
    {
        if (_isJump && Input.GetKey(KeyCode.Space))
        {
            if (_isUpCollision)
            {
                _isJump = false;
                return;
            }
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _isDownCollision)
        {
            _isJump = true;
            Jump();
            _startJumpPositionY = transform.position.y;
            _audioSource.PlayOneShot(_audioJump);
        }

        if (Input.GetKeyUp(KeyCode.Space) && _isJump || transform.position.y > _startJumpPositionY + _jumpHight)
        {
            _isJump = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _contactPoint = collision.GetContact(0);
        if (_contactPoint.normal == Vector2.left)
        {
            _isRightCollision = true;
        }
        else if (_contactPoint.normal == Vector2.right)
        {
            _isLeftCollision = true;
        }
        else if (_contactPoint.normal == Vector2.up)
        {
            _isDownCollision = true;
        }
        else if (_contactPoint.normal == Vector2.down)
        {
            _isUpCollision = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _contactPoint = collision.GetContact(0);

        if (_contactPoint.normal == Vector2.up)
        {
            if (collision.gameObject.TryGetComponent<IDestroyable>(out IDestroyable destroyable))
            {
                destroyable.DestroyThisGO();
                Jump();
            }
        }
        if (collision.gameObject.TryGetComponent<IEdible>(out IEdible edible))
        {
            edible.DestroyThisGO();
            _audioSource.PlayOneShot(_audioEatMashroom);
            _animator.SetTrigger("LevelUp");
            _isLevelUp = true;
        }
    }

    public float DirecrionMove()
    {
        float directionHorizontal = Input.GetAxis("Horizontal");
        if (_isRightCollision && directionHorizontal > 0)
        {
            return 0;
        }
        else if (_isLeftCollision && directionHorizontal < 0)
        {
            return 0;
        }

        return directionHorizontal;
    }

    private void ChachFlip()
    {
        if (_isWatchRight == false && DirecrionMove() > 0 && _isDownCollision)
        {
            Flip();
        }
        else if (_isWatchRight == true && DirecrionMove() < 0 && _isDownCollision)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isWatchRight = !_isWatchRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void Move()
    {
        if (!_isAttack)
        {
            _rigidbody2D.velocity = new Vector2(_moveSpeed * DirecrionMove(), _rigidbody2D.velocity.y);
        }
    }

    public void DestroyThisGO()
    {
        if (_isLevelUp)
        {
            _animator.SetTrigger("LevelDown");
        }
        else if(!_isLevelUp)
        {
            Jump();
            MarioAnimation marioAnimation = GetComponentInChildren<MarioAnimation>();
            marioAnimation.DiedAnimation();
            _audioSource.PlayOneShot(_audioDiad);
        }
    }
}
