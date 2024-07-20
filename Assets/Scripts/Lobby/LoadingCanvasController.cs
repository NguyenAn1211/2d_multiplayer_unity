using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingCanvasController : MonoBehaviour
{
    [SerializeField] private Button cancelButton;
    [SerializeField] private Animator animator;
    private NetWorkRunnerControl netWorkRunnerControl;


    private void Start()
    {
        netWorkRunnerControl = GlobalManager.Instance.netWorkRunnerControl;
        netWorkRunnerControl.OnStartedRunnerConnection += OnStartedRunnerConnection;
        netWorkRunnerControl.OnPlayerJoinSucess += OnPlayerJoinSucess;

        this.gameObject.SetActive(false);

        cancelButton.onClick.AddListener(netWorkRunnerControl.ShutDownRunner);
    }

    private void OnPlayerJoinSucess()
    {
        const string CLIP_NAME = "OUT";
        StartCoroutine(Utils.PlayAnimandSetStateWhenFinished(this.gameObject, animator, CLIP_NAME, false));
    }

    private void OnStartedRunnerConnection()
    {
        this.gameObject.SetActive(true);
        const string CLIP_NAME = "In";
        StartCoroutine(Utils.PlayAnimandSetStateWhenFinished(this.gameObject, animator, CLIP_NAME));
    }


    private void OnDestroy()
    {
        netWorkRunnerControl.OnStartedRunnerConnection -= OnStartedRunnerConnection;
        netWorkRunnerControl.OnPlayerJoinSucess -= OnPlayerJoinSucess;
    }
}
