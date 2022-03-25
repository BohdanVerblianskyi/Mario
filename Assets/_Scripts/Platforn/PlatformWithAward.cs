using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWithAward : MonoBehaviour
{
    [SerializeField] private WhichAward _whichAward;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    private GameObject _awardPrefab;
    private Transform _parent;
    private bool _isCreateAvard;

    public enum WhichAward
    {
        Coin,
        Mushroom
    }

    public WhichAward GetWhichAward()
    {
        return _whichAward;
    }

    public void SetSettingsAward(in GameObject awardPrefab,in Transform whoParentForAward)
    {
        _parent = whoParentForAward;
        _awardPrefab =awardPrefab;
    }

    private void CreateAward()
    {
        if (!_isCreateAvard)
        {
            Instantiate(_awardPrefab, transform.position + Vector3.up, Quaternion.identity, _parent);
            _isCreateAvard = true;
            _animator.SetTrigger("Hit");
            _audioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CreateAward();
    }
}
