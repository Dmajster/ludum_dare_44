using Assets.Scripts.Abstractions;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.Player {
    public class RespawnManager : Singleton<RespawnManager> {
        [SerializeField]
        public List<GameObject> RespawnPoints = new List<GameObject>();

        public void Respawn(GameObject player) {
            var playerData = PlayerManager.Instance.GetPlayer(player);
            if (playerData != null) {
                var component = RespawnPoints[playerData.RespawnIndex]?.GetComponent<Checkpoint>();
                if (component != null) {
                    playerData.Instance.transform.position = component.RespawnPoint.transform.position;
                }
            }
        }

        public int GetIndex(GameObject instance) {
            return RespawnPoints.IndexOf(instance);
        }

        public void Spawn(GameObject player, int index) {
            var playerData = PlayerManager.Instance.GetPlayer(player);

            if (playerData != null) {
                var component = RespawnPoints[index]?.GetComponent<Checkpoint>();
                if (component != null) {
                    playerData.Instance.transform.position = component.RespawnPoint.transform.position;
                }
            }
        }
    }
}
