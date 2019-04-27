using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.Lobby
{
    public class LobbyManager : MonoBehaviour
    {
        public Transform SpawnPoint;
        public GameObject PlayerPrefab;

        public Dictionary<PlayerIndex, GameObject> Players = new Dictionary<PlayerIndex, GameObject>();

        private void FixedUpdate()
        {
            for (var i = 0; i < 4; i++)
            {
                var playerIndex = (PlayerIndex) i;
                var state = GamePad.GetState(playerIndex);

                if (state.IsConnected)
                {
                    if (!Players.ContainsKey(playerIndex))
                    {
                        var newPlayer = Instantiate(PlayerPrefab, SpawnPoint.position, Quaternion.identity);
                        Players.Add(playerIndex, newPlayer );
                    }

                    Players[playerIndex].GetComponent<PlayerController>().PlayerIndex = playerIndex;
                }
            }
        }
    }
}
