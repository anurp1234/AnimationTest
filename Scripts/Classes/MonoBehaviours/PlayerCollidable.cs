using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollidable : MonoBehaviour, ICollidable
{
    PlayerCollissionContext collisionContext;

    void Start()
    {
        ICollisionContext context = GetComponent<ICollisionContext>();
        SetCollisionContext(context);
    }
    public ICollisionContext GetCollisionContext()
    {
        return collisionContext;
    }

    public void SetCollisionContext(ICollisionContext collisionContext)
    {
        this.collisionContext = (PlayerCollissionContext)collisionContext;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ICollisionContext otherContext = hit.gameObject.GetComponent<ICollisionContext>();
        CollisionProcessor.instance.ProcessCollision(collisionContext, otherContext);
    }
}
