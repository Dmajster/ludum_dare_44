using Assets.Scripts.Abstractions;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.Player
{
    public class RespawnManager : Singleton<RespawnManager>
    {
        public List<GameObject> RespawnPoints = new List<GameObject>();

        public void Respawn(PlayerIndex playerIndex)
        {
            var playerData = PlayerManager.Instance.GetPlayer(playerIndex);

            if (playerData != null)
            {
                playerData.Instance.transform.position = RespawnPoints[playerData.RespawnIndex].GetComponent<Checkpoint>().RespawnPoint.transform.position;
            }
        }

        public int GetIndex(GameObject instance)
        {
            return RespawnPoints.IndexOf(instance);
        }
    }
}
