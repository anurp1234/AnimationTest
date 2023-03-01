using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreEvent : ScriptableObject
{
    private List<ScoreEventListener> listeners = new List<ScoreEventListener>();
    public void Raise(int score)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(score);
        }
    }

    public void RegisterEventListener(ScoreEventListener listener)
    {
        listeners.Add(listener);
    }
    public void UnRegisterEventListener(ScoreEventListener listener)
    {
        listeners.Remove(listener);
    }
}
