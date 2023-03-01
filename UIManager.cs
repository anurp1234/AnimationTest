using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;

    GameSession session;
    public void RegisterScoreListener(GameSession session)
    {
        this.session = session;
        this.session.onScoreUpdate += UpdateScoreUI;
       
    }

    void UpdateScoreUI(int totalScore)
    {
        scoreText.text = totalScore.ToString();
    }

    void OnDestroy()
    {
        session.onScoreUpdate -= UpdateScoreUI;
    }
}
