using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    [SerializeField] GameData _gameData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( _gameData.LifeCounter > 0)
        {
            _gameData.LifeCounter -= 1;
            SceneManager.LoadScene(0);
        }
        else if ( _gameData.LifeCounter <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
