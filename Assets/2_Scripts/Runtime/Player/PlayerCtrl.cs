using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public enum PlayerType
{
    User,
    AI
}

public class PlayerCtrl : NetworkBehaviour
{
    [Header("[ References ]")] 
    public Transform handTr;
    
    [Header("[ Options ]")]
    public PlayerType playerType;

    [Header("[ Values ]")] 
    public int gold;
    public bool isDraw;
    
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
