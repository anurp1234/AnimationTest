using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct LoaderFactoryInfo
{
    public string EnvironmentPath;

    public string playerCharacterPath;

    public string collisionProcessorPath;

    public string scoreEventListenerPath;

    public string levelCreatorPath;

    public LoaderFactoryInfo(string EnvironmentPath, string playerCharacterPath, string collisionProcessorPath,string scoreEventListenerPath,string levelCreatorPath)
    {
        this.EnvironmentPath = EnvironmentPath;

        this.playerCharacterPath = playerCharacterPath;

        this.collisionProcessorPath = collisionProcessorPath;

        this.scoreEventListenerPath = scoreEventListenerPath;

        this.levelCreatorPath = levelCreatorPath;
      }
}
public class LevelFactory : MonoBehaviour
{

    [SerializeField]
    string EnvironmentPath;

    [SerializeField]
    string playerCharacterPath;

    [SerializeField]
    string collisionProcessorPath;

    [SerializeField]
    string scoreEventListenerPath;

    [SerializeField]
    string levelCreatorPath; 

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(new LoaderFactoryInfo(EnvironmentPath, playerCharacterPath, collisionProcessorPath, scoreEventListenerPath, levelCreatorPath));
    }

    void LoadLevel(LoaderFactoryInfo info)
    {
        GameObject sceneCreator = new GameObject("SceneCreator");
        SceneCreator creator = sceneCreator.AddComponent<SceneCreator>();
        creator.LoadScene(info);
        GameObject.Destroy(sceneCreator);
    }
}
