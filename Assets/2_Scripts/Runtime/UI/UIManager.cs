using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private UIPageMainMenu pageMainMenu;
    [SerializeField] private UIPageLoading pageLoading;
    [SerializeField] private UIPageLobby pageLobby;
    
    public UIPageMainMenu PageMainMenu => pageMainMenu;
    public UIPageLoading PageLoading => pageLoading;
    public UIPageLobby PageLobby => pageLobby;
    
    private void Start()
    {
        
    }
}