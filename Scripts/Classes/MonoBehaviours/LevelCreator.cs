using UnityEngine;
using System;
public class LevelCreator: MonoBehaviour
{
    public void LoadScene(LoaderFactoryInfo info)
    {
        GameObject environment = GameObject.Instantiate((GameObject)Resources.Load(info.environmentPath));
        GameObject playerObject = GameObject.Instantiate((GameObject)Resources.Load(info.playerCharacterPath));
        GameObject scoreListener = GameObject.Instantiate((GameObject)Resources.Load(info.scoreEventListenerPath));
        GameObject levelCreator = GameObject.Instantiate((GameObject)Resources.Load(info.levelCreatorPath));
        GameObject collisionProcessor = GameObject.Instantiate((GameObject)Resources.Load(info.collisionProcessorPath));
        GameObject gameSession = GameObject.Instantiate((GameObject)Resources.Load(info.gameSessionPath));
    }
}
