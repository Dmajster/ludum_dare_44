using System.Collections;
using Assets.Scripts.Player;
using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.Lobby {
    public class LobbyManager : MonoBehaviour {
        public Transform SpawnPoint;
        public GameObject PlayerPrefab;
        public Camera MovementCamera;

        public Color[] PlayerColors = new Color[5];

        public bool KeyboardPlayerActive = false;

        private void FixedUpdate() {
            if (Input.GetButton("Jump") && !KeyboardPlayerActive) {
                var playerData = new PlayerData {
                    Instance = Instantiate(PlayerPrefab, SpawnPoint.position, Quaternion.identity),
                    PlayerStatus = PlayerStatus.Alive
                };

                var playerController = playerData.Instance.GetComponent<PlayerController>();
                playerController.Input = new PlayerKeyboardInput();

                playerController.GetComponent<MeshRenderer>().material.color =
                    PlayerColors[PlayerManager.Instance.Players.Count];

                playerController.MovementCamera = MovementCamera;

                PlayerManager.Instance.Players.Add(playerData);

                RoundManager.Instance.StartRound();
                KeyboardPlayerActive = true;
            }

            for (var i = 0; i < 4; i++) {
                var playerIndex = (PlayerIndex)i;
                var state = GamePad.GetState(playerIndex);

                if (state.IsConnected) {
                    if (PlayerManager.Instance.GetPlayer(playerIndex) == null) {
                        var playerData = new PlayerData {
                            Instance = Instantiate(PlayerPrefab, SpawnPoint.position, Quaternion.identity),
                            Index = playerIndex,
                            PlayerStatus = PlayerStatus.Alive
                        };

                        var playerController = playerData.Instance.GetComponent<PlayerController>();
                        playerController.Input = new PlayerJoystickInput(playerIndex);

                        playerController.GetComponent<MeshRenderer>().material.color = PlayerColors[PlayerManager.Instance.Players.Count];

                        playerController.MovementCamera = MovementCamera;

                        PlayerManager.Instance.Players.Add(playerData);

                        RoundManager.Instance.StartRound();
                    }
                }
            }
        }
    }
}