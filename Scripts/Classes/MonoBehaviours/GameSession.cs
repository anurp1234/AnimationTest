using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSession : MonoBehaviour, iEventListener
{
    [SerializeField]
    ScoreEvent onScoreUpdate;

    [SerializeField]
    ScoreEvent onTotalScoreUpdate;

    int totalScore;

    public void OnEnable()
    {
        onScoreUpdate.RegisterEventListener(this);
    }

    public void OnDisable()
    {
        onScoreUpdate.UnRegisterEventListener(this);
    }

    public void OnEventRaised(int score)
    {
        totalScore += score;
        onTotalScoreUpdate.Raise(totalScore);
    }
}
