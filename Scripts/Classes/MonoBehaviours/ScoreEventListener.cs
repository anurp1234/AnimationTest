using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ScoreEventListener : MonoBehaviour
{
    public ScoreEvent scoreReceieverEvent;
    public event Action<int> scoreUpdatedResponseEvent;
    private void OnEnable()
    {
        scoreReceieverEvent.RegisterEventListener(this);
    }

    private void OnDisable()
    {
        scoreReceieverEvent.UnRegisterEventListener(this);
    }

    public void OnEventRaised(int score)
    {
        if(scoreUpdatedResponseEvent != null)
            scoreUpdatedResponseEvent.Invoke(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
