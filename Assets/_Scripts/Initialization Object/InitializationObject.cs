using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class InitializationObject : MonoBehaviour
{
    [SerializeField] private Mushroom _mushroomPrefab;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private GameData _gameData;

    private Mario _mario;
    private Enemy[] _enemys;
    private PlatformWithAward[] _platformsWithAward;

    private void Start()
    {
        Initialization();
    }

    private void Initialization()
    {
        _enemys = GetComponentsInChildren<Enemy>();
        _mario = GetComponentInChildren<Mario>();
        _platformsWithAward = GetComponentsInChildren<PlatformWithAward>();

        GameObject[] enemys = new GameObject[_enemys.Length];
        for (int i = 0; i < _enemys.Length; i++)
        {
            _enemys[i].SetWhoPlayer(_mario.gameObject);
            enemys[i] = _enemys[i].gameObject;
        }

        for (int i = 0; i < _platformsWithAward.Length; i++)
        {
            PlatformWithAward.WhichAward whatAward = _platformsWithAward[i].GetWhichAward();
            switch (whatAward)
            {
                case PlatformWithAward.WhichAward.Coin:
                    _platformsWithAward[i].SetSettingsAward(_coinPrefab.gameObject, transform);
                    break;
                case PlatformWithAward.WhichAward.Mushroom:
                    _platformsWithAward[i].SetSettingsAward(_mushroomPrefab.gameObject, transform);
                    break;
                default:
                    break;
            }
        }
    }
}
