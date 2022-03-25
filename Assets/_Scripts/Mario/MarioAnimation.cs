using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Mario _mario;

    private void Update()
    {
        AnimationMove();
        AnimationJump();
    }

    private void Start()
    {
        _mario = GetComponentInParent<Mario>();
    }

    private void AnimationMove()
    {
        if (_mario.IsDownCollision && _mario.DirecrionMove() != 0f)
        {
            _animator.SetBool("Move", true);
        }
        else if ( _mario.DirecrionMove() == 0f)
        {
            _animator.SetBool("Move", false);
        }
    }

    public void DiedAnimation()
    {
        _animator.SetTrigger("Died");
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void AnimationJump()
    {
        if (!_mario.IsDownCollision)
        {
            _animator.SetBool("Jump", true);
        }
        else if (_mario.IsDownCollision)
        {
            _animator.SetBool("Jump", false);
        }
    }
}
