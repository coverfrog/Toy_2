using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SceneGame : NetworkBehaviour
{
    [Header("[ Resources ]")]
    [SerializeField] private PlayerCtrl playerCtrlOrigin;

    [Header("[ Option ]")]
    [SerializeField] private CardDeck cardDeck;
    [SerializeField] private List<PlayerCtrl> playerCtrlList = new();

    private void Start()
    {
        
    }

    public override void OnNetworkSpawn()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        PlayerCtrl playerCtrl = Instantiate(playerCtrlOrigin, transform, true);
        playerCtrl.GetComponent<NetworkObject>().Spawn();
        
        playerCtrlList.Add(playerCtrl);
    }
}