using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int hitValue = 10;
    [SerializeField] TextMeshProUGUI scoreField;

    int currentScore;

    // todo singleton pattern

    private void Start()
    {
        currentScore = 0;
        scoreField.text = currentScore.ToString();
    }

    public void AddScore()
    {
        currentScore += hitValue;
        scoreField.text = currentScore.ToString();
    }
}
