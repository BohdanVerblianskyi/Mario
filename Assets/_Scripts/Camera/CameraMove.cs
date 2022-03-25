using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _aсtiveDisatns;

    private void Update()
    {
        if (transform.position.x + _aсtiveDisatns < _player.position.x )
        {
            transform.position = new Vector3(transform.position.x + _moveSpeed * Time.deltaTime,transform.position.y, transform.position.z) ;
        }
    }
}
