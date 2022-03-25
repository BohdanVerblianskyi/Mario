using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textLifeCounter;
    [SerializeField] private TextMeshProUGUI _textScoreCounter;
    [SerializeField] private TextMeshProUGUI _textCoinCouret;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private GameData _gameData;
    [SerializeField] private int _howMonyCostEnemy;
    [SerializeField] private float _timer;
    [SerializeField] private DepartureScore _departureScorePrefab;

    private void Start()
    {
        _textLifeCounter.text = _gameData.LifeCounter.ToString();
        EventMeneger.OnAddScore += CreateDepartureScore;
        EventMeneger.OnAddCoin += AddCoin;
    }

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        int timer = (int)(_timer - Time.time);
        
        _time.text = timer.ToString();
    }

    private void AddCoin()
    {
        _gameData.CoinCouret++;
        _textCoinCouret.text = _gameData.CoinCouret.ToString();
    }

    private void AddScore(int score)
    {
        _gameData.ScoreCounter += score;
        _textScoreCounter.text = _gameData.ScoreCounter.ToString();
    }


    private void CreateDepartureScore(Vector2 position, int score)
    {
        DepartureScore departureScore = Instantiate(_departureScorePrefab, position, Quaternion.identity);
        departureScore.SetHowManyScore(score);
        AddScore(score);
    }
 }
