using System.Collections.Generic;
using Assets.Scripts.Abstractions;
using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.Player
{
    public class RespawnManager : Singleton<RespawnManager>
    {
        public List<Transform> RespawnPoints = new List<Transform>();

        public void Respawn(PlayerIndex playerIndex)
        {
            var playerData = PlayerManager.Instance.GetPlayer(playerIndex);

            if (playerData != null)
            {
                playerData.Instance.transform.position = RespawnPoints[0].position;

            }
            
        }
    }
}
