using System.Linq;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets
{
    public class Endzone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var finishedPlayerData = PlayerManager.Instance.GetPlayer(other.gameObject);
            finishedPlayerData.PlayerStatus = PlayerStatus.Finished;

            if (PlayerManager.Instance.Players.All(playerData => playerData.PlayerStatus == PlayerStatus.Dead || playerData.PlayerStatus == PlayerStatus.Finished ))
            {
                RoundManager.Instance.EndRound();
            }
        }
    }
}
