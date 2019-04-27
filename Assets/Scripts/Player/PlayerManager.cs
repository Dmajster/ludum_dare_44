﻿using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Abstractions;
using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.Player
{
    [Serializable]
    public class PlayerData
    {
        public PlayerIndex Index;
        public GameObject Instance;

        public PlayerController Controller => Instance.GetComponent<PlayerController>();
    }

    [Serializable]
    public class PlayerManager : Singleton<PlayerManager>
    {
        public List<PlayerData> Players = new List<PlayerData>();

        public PlayerData GetPlayer(PlayerIndex playerIndex)
        {
            return Players.FirstOrDefault(playerData => playerData.Index == playerIndex);
        }

        public PlayerData GetPlayer(GameObject playerInstance)
        {
            return Players.FirstOrDefault(playerData => playerData.Instance == playerInstance);
        }
    }
}