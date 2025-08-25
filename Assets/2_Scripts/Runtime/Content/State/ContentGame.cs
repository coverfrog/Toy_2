using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContentGame : State<ContentManager>
{
    protected override void OnEnter(ContentManager owner)
    {
        SceneLoader.LoadSceneNetwork("Game");
    }

    protected override void OnUpdate(ContentManager owner)
    {
       
    }

    protected override void OnExit(ContentManager owner)
    {
        
    }
}