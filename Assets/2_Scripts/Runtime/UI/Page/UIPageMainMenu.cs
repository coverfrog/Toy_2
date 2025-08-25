using System;
using UnityEngine;
using UnityEngine.UI;

public class UIPageMainMenu : UIPage
{
    [Header("[ References ]")]
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    private void Start()
    {
        hostButton.onClick.AddListener(() =>
        {
            hostButton.interactable = false;
            clientButton.interactable = false;
            
            ContentManager.Instance.networkManager.StartHost();
        });
        
        clientButton.onClick.AddListener(() =>
        {
            hostButton.interactable = false;
            clientButton.interactable = false;
            
            ContentManager.Instance.networkManager.StartClient();
        });
    }

    private void OnEnable()
    {
        hostButton.interactable = true;
        clientButton.interactable = true;
    }
}