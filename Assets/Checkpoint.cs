using Assets.Scripts.Player;
using UnityEngine;

namespace Assets
{
    public class Checkpoint : MonoBehaviour
    {
        public GameObject RespawnPoint;

        private void OnTriggerEnter(Collider other)
        {
            var index = RespawnManager.Instance.GetIndex(gameObject);

            var playerData = PlayerManager.Instance.GetPlayer(other.gameObject);

            if (playerData.RespawnIndex < index)
            {
                playerData.RespawnIndex = index;
            }
        }
    }
}
