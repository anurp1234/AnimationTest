using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCollidable : MonoBehaviour, ICollidable
{
    ICollisionContext collisionContext;
    public ICollisionContext Context
    {
        get
        {
            return collisionContext;
        }
        set
        {
            collisionContext = value;
        }
    }

    void Start()
    {
        collisionContext  = GetComponent<GemCollissionContext>();
        Debug.Assert(collisionContext != null, "Object should have collision context");
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        ICollisionContext otherContext = collisionInfo.gameObject.GetComponent<ICollisionContext>();
        //Todo add assert that the other object has a collision context
        CollisionProcessor.instance.ProcessCollision(collisionContext, otherContext);
    }

}
