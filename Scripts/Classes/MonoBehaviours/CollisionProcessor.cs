using System.Collections.Generic;
using UnityEngine;

public class CollisionProcessor : Singleton<CollisionProcessor>
{
    public ScoreEvent scoreEvent;

    List<ICollissionProcessor> collisionProcessors;
    void Start()
    {
        collisionProcessors = new List<ICollissionProcessor>();
        collisionProcessors.Add(new PlayerCollisionProcessor());
    }
    public void ProcessCollision(ICollisionContext a, ICollisionContext b)
    {
        int processorCount = collisionProcessors.Count;
        for (int i = 0; i < processorCount; i++)
        {
            bool isHandled = collisionProcessors[i].TryProcess(this, a, b);
            if (isHandled)
                return;
        }
    }
}

public interface ICollissionProcessor
{
    bool TryProcess(CollisionProcessor processor, ICollisionContext a, ICollisionContext b);
}

public class PlayerCollisionProcessor : ICollissionProcessor
{
    public bool TryProcess(CollisionProcessor processor,ICollisionContext a, ICollisionContext b)
    {
        if (a is PlayerCollissionContext || b is PlayerCollissionContext)
        {
            ICollisionContext other = a is PlayerCollissionContext ? b : a;
            if (other is GemCollissionContext)
            {
                GemCollissionContext gemContext = null;
                gemContext = (GemCollissionContext)other;
                GameObject.Destroy(gemContext.gameObject);
                processor.scoreEvent.Raise(gemContext.scoreIncrement);
            }
            else if (other is IgnoreCollisionContext)
            {
                //Nothing to be done here
            }
            else
            {
                Debug.Assert(false, "NYI");
            }
            return true;
        }
        return false;
    }

}
