using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _playerWeak;
    [SerializeField] private GameObject _playerStrong;
    [SerializeField] private Debry _debry;
    [SerializeField] private Vector2[] _creatiorPoints;

    private void CreateDebryAndDestroy()
    {
        for (int i = 0; i < _creatiorPoints.Length; i++)
        {
            Vector3 positionCreate = new Vector3(transform.position.x + _creatiorPoints[i].x, transform.position.y + _creatiorPoints[i].y, transform.position.z);
            Debry debry = Instantiate(_debry, positionCreate, Quaternion.identity);
            debry.AddForceDebry(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z));
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _playerStrong)
        {
            CreateDebryAndDestroy();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _playerWeak)
        {
            _animator.SetTrigger("Hit");
            _audioSource.Play();
        }
    }

}
