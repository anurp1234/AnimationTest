using UnityEngine;
using System;
public class SceneCreator: MonoBehaviour
{
    /*Ideally this will be done in async manner using addressables, while showing loading bar, given the time constraints
     * loading the scene objects directly from resources
     */
 
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
