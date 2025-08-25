using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UIPageLobby : UIPage
{
    [Header("[ References ]")] 
    [SerializeField] private RectTransform contentRt;
    [SerializeField] private Button startBtn;
    
    [Header("[ Resources ]")]
    [SerializeField] private UIItemPlayer itemPlayerPrefab;

    private readonly List<UIItemPlayer> _itemPlayers = new();

    private void OnEnable()
    {
        startBtn.gameObject.SetActive(NetworkManager.Singleton.IsServer);
    }

    private void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            ContentManager.Instance.isGame = true;
        });
    }

    public void Init()
    {
        Release();
        Spawns();
    }

    public void Release()
    {
        for (int i = _itemPlayers.Count - 1; i >= 0; i--)
        {
            _itemPlayers[i].SetActive(false);
        }
    }

    private void Spawns()
    {
        foreach (NetworkClient networkClient in NetworkManager.Singleton.ConnectedClientsList)
        {
            Spawn(networkClient);
        }
    }
    
    private void Spawn(NetworkClient networkClient)
    {
        UIItemPlayer item = _itemPlayers.FirstOrDefault(x => !x.gameObject.activeInHierarchy);

        if (item != null)
        {
            item.SetActive(true);
        }

        else
        {
            item = Instantiate(itemPlayerPrefab, contentRt);
            
            _itemPlayers.Add(item);
        }
        
        item.Init(networkClient);
    }
}