using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    public int score { get; private set; }

    private ScoreCounterUI scoreCounterUI;

    private void Start()
    {
        scoreCounterUI = GameObject.Find("Score Canvas").GetComponentInChildren<ScoreCounterUI>();
    }

    public void CollectibleCollected(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreCounterUI.UpdateScoreText(score);
    } 
}
