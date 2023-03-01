using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCreator: MonoBehaviour
{
    public void LoadScene(LoaderFactoryInfo info)
    {
        GameObject environment = GameObject.Instantiate((GameObject)Resources.Load(info.EnvironmentPath));
        GameObject playerObject = GameObject.Instantiate((GameObject)Resources.Load(info.playerCharacterPath));
        GameObject scoreListener = GameObject.Instantiate((GameObject)Resources.Load(info.scoreEventListenerPath));
        GameObject levelCreator = GameObject.Instantiate((GameObject)Resources.Load(info.levelCreatorPath));
        GameObject collisionProcessor = GameObject.Instantiate((GameObject)Resources.Load(info.collisionProcessorPath));
    }
}
