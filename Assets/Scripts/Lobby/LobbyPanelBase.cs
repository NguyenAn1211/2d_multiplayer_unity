using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPanelBase : MonoBehaviour
{
    [field: SerializeField, Header("LobbyPanel Variables")]
    [SerializeField] public LobbyPanelType panelType {get; private set;}
    [SerializeField] private Animator panelAnimator;
    protected LobbyUIManager lobbyUIManager;

    public enum LobbyPanelType
    {
        None,
        CreateNicknamePanel,
        MiddleSelectionPanel
    }


    public virtual void InitPanel(LobbyUIManager uiManager) 
    {
        lobbyUIManager = uiManager;

    }

    public void ShowPanel()
    {
        this.gameObject.SetActive(true);
        const string POP_IN_NAME = "In";
        panelAnimator.Play(POP_IN_NAME);
    }


    protected void ClosePanel()
    {
        const string POP_OUT_NAME = "Out";
        StartCoroutine(Utils.PlayAnimandSetStateWhenFinished(gameObject, panelAnimator, POP_OUT_NAME, false));
    }
}
