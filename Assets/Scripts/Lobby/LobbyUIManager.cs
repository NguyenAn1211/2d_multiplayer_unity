using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{

    [SerializeField] private LobbyPanelBase[] lobbyPanels;

    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var lobby in lobbyPanels)
        {
            lobby.InitPanel(this);
        }
    }


    public void ShowPanel(LobbyPanelBase.LobbyPanelType type)
    {
        foreach(var lobby in lobbyPanels)
        {
            if(lobby.panelType == type)
            {
                lobby.ShowPanel();
                break;
            }
        }
    }

   
    
}
