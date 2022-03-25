using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestResult;
    [SerializeField] private GameData _gameData;
    [SerializeField] private int _HowManyLifeMario;

    private void Start()
    {
        Debug.Log(_gameData.ScoreCounter);
        if (_gameData.ScoreCounter != 0)
        {
            _bestResult.text = _gameData.ScoreCounter.ToString();
        }
    }

    public void StartGameScene()
    {
        _gameData.LifeCounter = _HowManyLifeMario;
        _gameData.CoinCouret = 0;
        _gameData.ScoreCounter = 0;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
