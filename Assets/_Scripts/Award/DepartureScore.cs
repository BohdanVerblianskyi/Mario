using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DepartureScore : MonoBehaviour
{
    [SerializeField] private TextMesh _textScore;

    public void SetHowManyScore(int score)
    {
        _textScore.text = score.ToString();
    }

    private void DestroyThisGO()
    {
        Destroy(gameObject);
    }
}
