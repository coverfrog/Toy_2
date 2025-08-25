using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SceneGame : MonoBehaviour
{
    [Header("[ Asset References ]")]
    [SerializeField] private PlayerCtrl playerCtrlOrigin;
    
    [Header("[ Value ]")]
    [SerializeField] private PlayerCtrl playerCtrl;
    
    private void Start()
    {
        playerCtrl = Instantiate(playerCtrlOrigin, transform, true);
        playerCtrl.GetComponent<NetworkObject>().Spawn();
    }
}