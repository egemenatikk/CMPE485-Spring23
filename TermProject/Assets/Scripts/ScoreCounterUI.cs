using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounterUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();   
    }

    public void updateScoreText(ScoreCounter scoreCounter) 
    {
        scoreText.text = scoreCounter.score.ToString();
    } 
}
