using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreEvent : ScriptableObject
{
    private List<iEventListener> listeners = new List<iEventListener>();
    public void Raise(int score)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(score);
        }
    }

    public void RegisterEventListener(iEventListener listener)
    {
        listeners.Add(listener);
    }
    public void UnRegisterEventListener(iEventListener listener)
    {
        listeners.Remove(listener);
    }
}
