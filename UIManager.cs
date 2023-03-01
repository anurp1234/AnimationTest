using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour, iEventListener
{
    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    ScoreEvent onTotalScoreUpdate;

    public void OnEnable()
    {
        onTotalScoreUpdate.RegisterEventListener(this);
    }

    public void OnDisable()
    {
        onTotalScoreUpdate.UnRegisterEventListener(this);
    }

    public void OnEventRaised(int totalScore)
    {
        scoreText.text = totalScore.ToString();
    }


}
