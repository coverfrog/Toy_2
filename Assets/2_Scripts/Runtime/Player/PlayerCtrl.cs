using System;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public enum PlayerType
{
    User,
    AI
}

public class PlayerCtrl : NetworkBehaviour
{
    [Header("[ Values ]")] 
    public PlayerType playerType;

    private StateMachine<PlayerCtrl> _mStateMachine;

    private void Start()
    {
        _mStateMachine = new StateMachine<PlayerCtrl>(this);
        
        _mStateMachine.AddState<PlayerIdle>(0);
        
        _mStateMachine.Run();
    }

    private void Update()
    {
        _mStateMachine?.Update();
    }

    public override void OnNetworkSpawn()
    {
        gameObject.name = $"Player Ctrl [ {(IsOwner ? "Owner" : "Other")} ]";
    }
}
