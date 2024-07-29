using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : NetworkBehaviour, IPlayerJoined, IPlayerLeft
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private NetworkPrefabRef playerNetworkPrefabRef = NetworkPrefabRef.Empty;



    public override void Spawned()
    {
        if (Runner.IsServer)
        {
            foreach (var item in Runner.ActivePlayers)
            {
                SpawnPlayer(item);
            }
        }
    }


    private void SpawnPlayer(PlayerRef playerRef)
    {


        if (Runner.IsServer)
        {
            var index = playerRef % spawnPoints.Length;
            var spawnPoint = spawnPoints[index].transform.position;
            var playerObj =  Runner.Spawn(playerNetworkPrefabRef, spawnPoint, Quaternion.identity, playerRef);

            Runner.SetPlayerObject(playerRef, playerObj);
        }
    }


    public void PlayerJoined(PlayerRef player)
    {
       SpawnPlayer(player);
    }

    public void PlayerLeft(PlayerRef player)
    {
        DespawnePlayer(player);
    }

    private void DespawnePlayer(PlayerRef playerRef)
    {
        if(Runner.IsServer)
        {
            if(Runner.TryGetPlayerObject(playerRef, out var playerNetworkObj))
            {
                Runner.Despawn(playerNetworkObj);
            }


            //Reset Player OBj
            Runner.SetPlayerObject(playerRef, null);
        }
    }
}
