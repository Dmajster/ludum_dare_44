using Assets.Scripts.Abstractions;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.Player
{
    public class RespawnManager : Singleton<RespawnManager>
    {
        public List<GameObject> RespawnPoints = new List<GameObject>();

        public void Respawn(GameObject player)
        {
            var playerData = PlayerManager.Instance.GetPlayer(player);

            if (playerData != null)
            {
                playerData.Instance.transform.position = RespawnPoints[playerData.RespawnIndex].GetComponent<Checkpoint>().RespawnPoint.transform.position;
            }
        }

        public int GetIndex(GameObject instance)
        {
            return RespawnPoints.IndexOf(instance);
        }

        public void Spawn(GameObject player, int index)
        {
            var playerData = PlayerManager.Instance.GetPlayer(player);

            if (playerData != null)
            {
                playerData.Instance.transform.position = RespawnPoints[index].GetComponent<Checkpoint>().RespawnPoint.transform.position;
            }
        }
    }
}
