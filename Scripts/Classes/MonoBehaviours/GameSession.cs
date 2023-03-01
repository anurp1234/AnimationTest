using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSession : MonoBehaviour
{
    int score;
    public event Action<int> onScoreUpdate;

    ScoreEventListener scoreListener;
    public void RegisterScoreListenter(ScoreEventListener scoreListener)
    {
        this.scoreListener = scoreListener;
        scoreListener.scoreUpdatedResponseEvent += OnScoreUpdate;
    }

    void OnScoreUpdate(int scoreIncrement)
    {
        score += scoreIncrement;
        if (onScoreUpdate != null)
            onScoreUpdate.Invoke(score);
    }

    void OnDestroy()
    {
        scoreListener.scoreUpdatedResponseEvent -= OnScoreUpdate;
    }

}
