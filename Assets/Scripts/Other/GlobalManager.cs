using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance { get; private set; }

    [field :SerializeField] public NetWorkRunnerControl netWorkRunnerControl{get; private set;}
    [SerializeField] private GameObject parentObj;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(parentObj);
        }
    }
}
