using TMPro;
using Unity.Netcode;
using UnityEngine;

public class UIItemPlayer : UIItem
{
    [Header("[ References ]")]
    [SerializeField] private TMP_Text nameText;
    
    private NetworkClient _networkClient;

    public void Init(NetworkClient networkClient)
    {
        _networkClient = networkClient;

        nameText.text = $"Client {networkClient.ClientId}";
    }
}
