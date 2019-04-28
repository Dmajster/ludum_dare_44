using Assets.Scripts.Abstractions;
using Assets.Scripts.CameraManager;
using Assets.Scripts.Player;
using UnityEngine;
using XInputDotNetPure;

namespace Assets {
    public class RoundManager : Singleton<RoundManager> {

        public int StartingLifes = 2;

        public void StartRound() {
            var playerCount = PlayerManager.Instance.Players.Count;

            if (playerCount == 0) {
                Debug.LogWarning($"Player count {playerCount}");
                return;
            }

            //Find naughty player
            var naughty = Random.Range(0, playerCount);

            Debug.Log($"Player count {playerCount}, {naughty}");


            CameraManager.Instance.ShiftTo(0);

            //Set roles to all players
            for (var i = 0; i < playerCount; i++) {
                var playerData = PlayerManager.Instance.Players[i];
                playerData.Controller.gameObject.SetActive(true);
                playerData.PlayerRole = i == naughty ? PlayerRole.Naughty : PlayerRole.Saint;
                playerData.RespawnIndex = 0;
                playerData.PlayerStatus = PlayerStatus.Alive;
                playerData.LifesLeft = StartingLifes;
                playerData.Controller.Spawn(0);
                playerData.Controller.Gravity = 0;
            }
        }

        public void EndRound() {
            StartRound();
        }
    }
}
