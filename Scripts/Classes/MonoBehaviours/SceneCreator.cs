using UnityEngine;
using System;
public class SceneCreator: MonoBehaviour
{
    public void LoadScene(LoaderFactoryInfo info)
    {
        GameObject.Instantiate((GameObject)Resources.Load(info.environmentPath));
        GameObject.Instantiate((GameObject)Resources.Load(info.playerCharacterPath));
        GameObject.Instantiate((GameObject)Resources.Load(info.levelCreatorPath));
        GameObject.Instantiate((GameObject)Resources.Load(info.collisionProcessorPath));
        GameObject.Instantiate((GameObject)Resources.Load(info.gameSessionPath));
        GameObject.Destroy(gameObject);
    }
}
