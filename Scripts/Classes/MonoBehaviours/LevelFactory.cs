using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct LoaderFactoryInfo
{
    public string environmentPath;

    public string playerCharacterPath;

    public string collisionProcessorPath;

    public string scoreEventListenerPath;

    public string levelCreatorPath;

    public string gameSessionPath;
    public LoaderFactoryInfo(string EnvironmentPath, string playerCharacterPath, string collisionProcessorPath,string scoreEventListenerPath,string levelCreatorPath, string GameSessionPath)
    {
        this.environmentPath = EnvironmentPath;

        this.playerCharacterPath = playerCharacterPath;

        this.collisionProcessorPath = collisionProcessorPath;

        this.scoreEventListenerPath = scoreEventListenerPath;

        this.levelCreatorPath = levelCreatorPath;

        this.gameSessionPath = GameSessionPath;
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

    [SerializeField]
    string gameSessionPath;
    void Start()
    {
        CreateLevel(new LoaderFactoryInfo(EnvironmentPath, playerCharacterPath, collisionProcessorPath, scoreEventListenerPath, levelCreatorPath, gameSessionPath));
    }
    void CreateLevel(LoaderFactoryInfo info)
    {
        GameObject sceneCreatorGO = new GameObject("SceneCreator");
        LevelCreator sceneCreator = sceneCreatorGO.AddComponent<LevelCreator>();
        sceneCreator.LoadScene(info);
        GameObject.Destroy(sceneCreator);
    }
}
