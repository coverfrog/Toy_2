using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContentLobby : State<ContentManager>
{
    protected override void OnEnter(ContentManager owner)
    {
        UIPageLobby lobby = UIManager.Instance.PageLobby;

        lobby.Release();
        
        SceneLoader.LoadScene("Lobby", this, null, null, onComplete: () =>
        {
            lobby.Init();
            lobby.SetActive(true);
        });
    }

    protected override void OnUpdate(ContentManager owner)
    {
        
    }

    protected override void OnExit(ContentManager owner)
    {
        UIPageLobby lobby = UIManager.Instance.PageLobby;
        
        lobby.SetActive(false);
    }
}