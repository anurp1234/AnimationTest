using UnityEngine;
using System;

public class SceneCreator: MonoBehaviour
{
    public event Action<GameSession, ScoreEventListener, UIManager> onLoadComplete;
    public void LoadScene(LoaderFactoryInfo info)
    {
        GameObject environment = GameObject.Instantiate((GameObject)Resources.Load(info.environmentPath));
        GameObject playerObject = GameObject.Instantiate((GameObject)Resources.Load(info.playerCharacterPath));
        GameObject scoreListener = GameObject.Instantiate((GameObject)Resources.Load(info.scoreEventListenerPath));
        GameObject levelCreator = GameObject.Instantiate((GameObject)Resources.Load(info.levelCreatorPath));
        GameObject collisionProcessor = GameObject.Instantiate((GameObject)Resources.Load(info.collisionProcessorPath));
        GameObject gameSession = GameObject.Instantiate((GameObject)Resources.Load(info.gameSessionPath));

        GameSession session = gameSession.GetComponent<GameSession>();
        ScoreEventListener listener = scoreListener.GetComponent<ScoreEventListener>();
        UIManager manager = environment.GetComponentInChildren<UIManager>();

        onLoadComplete(session, listener, manager);
    }
}
