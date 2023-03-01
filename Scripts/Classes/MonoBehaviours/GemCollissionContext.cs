using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollissionContext : MonoBehaviour, ICollisionContext
{
    [SerializeField]
    int pScoreIncrement;

    public int scoreIncrement
    {
        get
        {
            return pScoreIncrement;
        }
    }

}
