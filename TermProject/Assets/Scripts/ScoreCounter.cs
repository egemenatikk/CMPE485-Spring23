using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    public int score { get; private set; }
    public UnityEvent<ScoreCounter> OnCollectibleCollected;
    
    public void CollectibleCollected(int scoreToAdd)
    {
        score += scoreToAdd;
        OnCollectibleCollected.Invoke(this);
    } 
}
