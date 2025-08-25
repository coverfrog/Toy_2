using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ContentManager : Singleton<ContentManager>
{
    [Header("[ References ]")]
    public NetworkManager networkManager;
    
    [Header("[ Values ]")]
    public bool isGame;
    
    private StateMachine<ContentManager> _mStateMachine;

    private void Start()
    {
        _mStateMachine = new StateMachine<ContentManager>(this);

        _mStateMachine.AddState<ContentMainMenu>(0);
        _mStateMachine.AddState<ContentLobby>(0);
        _mStateMachine.AddState<ContentGame>(0);

        _mStateMachine.AddTransition<ContentMainMenu, ContentLobby>(0, () => networkManager.IsConnectedClient);
        _mStateMachine.AddTransition<ContentLobby, ContentGame>(0, () => isGame);
        
        _mStateMachine.Run();
    }

    private void Update()
    {
        _mStateMachine?.Update();
    }
}