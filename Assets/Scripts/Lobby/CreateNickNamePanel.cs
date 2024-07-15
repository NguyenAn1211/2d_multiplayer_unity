using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CreateNickNamePanel : LobbyPanelBase
{
    [Header("Create Nickname Panel Variables")]
    [SerializeField] private TMP_InputField nicknameInputField;
    [SerializeField] private Button createNicknameButton;
    private const int MIN_NICKNAME_LENGTH = 2;



    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);
        createNicknameButton.interactable = false; //disable button until input is valid
        createNicknameButton.onClick.AddListener(OnClickCreateNickname);
        nicknameInputField.onValueChanged.AddListener(OnInpuValueChanged);
    }


   

    private void OnInpuValueChanged(string arg0)
    { 

        createNicknameButton.interactable = arg0.Length >= 2;
    
    }



    private void OnClickCreateNickname()
    {
        var nickname = nicknameInputField.text;
        if (nickname.Length >= 2)
        {
            base.ClosePanel();
            lobbyUIManager.ShowPanel(LobbyPanelType.MiddleSelectionPanel);
        }
       
    }

}
