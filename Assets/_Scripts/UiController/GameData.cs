using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data",fileName = "New GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private int _lifeCounter;
    [SerializeField] private int _scoreCounter;
    [SerializeField] private int _coinCouret;

    public int LifeCounter { get => _lifeCounter; set => _lifeCounter = value; }
    public int ScoreCounter { get => _scoreCounter; set => _scoreCounter = value; }
    public int CoinCouret { get => _coinCouret; set => _coinCouret = value; }
}
