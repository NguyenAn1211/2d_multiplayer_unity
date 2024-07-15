using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MiddleSectionPanel : LobbyPanelBase
{
    [Header ("Middle Section Panel")]
    [SerializeField] private Button joinRandomButton;
    [SerializeField] private Button joinbyCodeButton;
    [SerializeField] private Button createRoomButton;
    [SerializeField] private Button backButton;


    [SerializeField] private TMP_InputField joinbyCodeInputfield;
    [SerializeField] private TMP_InputField createRoomInputfield;
    private NetWorkRunnerControl netWorkRunnerControl;


    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);
        netWorkRunnerControl = GlobalManager.Instance.netWorkRunnerControl;


        backButton.onClick.AddListener(OnClickBackButton);
        joinRandomButton.onClick.AddListener(JoinRandomRoom);
        createRoomButton.onClick.AddListener(() => CreateRoom(GameMode.Host, createRoomInputfield.text));
        joinbyCodeButton.onClick.AddListener(() => CreateRoom(GameMode.Client, joinbyCodeInputfield.text    ));
    }

   

    private void CreateRoom(GameMode mode, string field)
    {
        if (field.Length >= 2)
        {
            Debug.Log($"--------------------{mode}-------------------------)");
            netWorkRunnerControl.StartGame(mode, field);
        }
    }

    private void JoinRandomRoom()
    {
        Debug.Log($"--------------------JoinRandomRoom-------------------------)");
        netWorkRunnerControl.StartGame(GameMode.AutoHostOrClient, string.Empty); 
    }





    public void OnClickBackButton()
    {
        base.ClosePanel();
        lobbyUIManager.ShowPanel(LobbyPanelType.CreateNicknamePanel);
    }
}
