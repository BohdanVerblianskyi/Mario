using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _forceJump;
    [SerializeField] private int _howManyScore;

    private void Start()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _forceJump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EventMeneger.SendAddScore(transform.position, _howManyScore);
        EventMeneger.SendAddCoin();
        Destroy(gameObject);
    }
}
