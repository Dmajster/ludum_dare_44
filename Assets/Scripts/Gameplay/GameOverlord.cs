using System.Collections.Generic;
using Assets.Scripts.Abstractions;
using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.Player {
    public class GameOverlord : Singleton<GameOverlord> {
        private int _NumberOfPlayers = 0;


        // Game logic
        public bool _IsGameOver = false;
        private int _VictimIndex = 0;
        private int _NumberOfPlayersAlive = 0;

        public void InitGameOverlord() {
            if (PlayerManager.Instance != null) {
                _NumberOfPlayers = PlayerManager.Instance.Players.Count;
            }
            InitGameLogic();
        }

        private void InitGameLogic() {
            _IsGameOver = false;
            _NumberOfPlayersAlive = _NumberOfPlayers;
            _VictimIndex = GenerateVictimIndex(_NumberOfPlayers);
            if (PlayerManager.Instance.Players.Count > 0) {
                PlayerManager.Instance.SetPlayerAsVictim(_VictimIndex);
            } else {
                Debug.LogError("ERR: COULD NOT CHOOSE VICTIM !");
            }
            // Add RoundManager logic here  
        }

        private int GenerateVictimIndex(int numberOfPlayers) {
            return Random.Range((int)0, (int)numberOfPlayers + 1);
        }
    }
}
