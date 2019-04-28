using System.Collections;
using Assets.Scripts.Player;
using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.Lobby
{
    public class LobbyManager : MonoBehaviour
    {
        public Transform SpawnPoint;
        public GameObject PlayerPrefab;
        public Camera MovementCamera;

        private void FixedUpdate()
        {
            for (var i = 0; i < 4; i++)
            {
                var playerIndex = (PlayerIndex) i;
                var state = GamePad.GetState(playerIndex);

                if (state.IsConnected)
                {
                    if (PlayerManager.Instance.GetPlayer(playerIndex) == null)
                    {
                        var playerData = new PlayerData
                        {
                            Instance = Instantiate(PlayerPrefab, SpawnPoint.position, Quaternion.identity),
                            Index = playerIndex,
                            PlayerStatus = PlayerStatus.Alive
                        };

                        var playerController = playerData.Instance.GetComponent<PlayerController>();
                        playerController.PlayerIndex = playerIndex;
                        playerController.MovementCamera = MovementCamera;

                        PlayerManager.Instance.Players.Add(playerData);

                        RoundManager.Instance.StartRound();
                    }
                }
            }
        }
    }
}