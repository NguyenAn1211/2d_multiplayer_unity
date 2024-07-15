using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiddleSectionPanel : LobbyPanelBase
{


    [SerializeField] private Button backButton;

    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);

        backButton.onClick.AddListener(OnClickBackButton);
        
    }


    public void OnClickBackButton()
    {
        base.ClosePanel();
        lobbyUIManager.ShowPanel(LobbyPanelType.CreateNicknamePanel);
    }
}
