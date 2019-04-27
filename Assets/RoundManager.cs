using Assets.Scripts.Abstractions;
using Assets.Scripts.Player;
using UnityEngine;
using XInputDotNetPure;

namespace Assets
{
    public class RoundManager : Singleton<RoundManager>
    {
        public void StartRound()
        {
            var playerCount = PlayerManager.Instance.Players.Count;

            if (playerCount == 0)
            {
                Debug.LogWarning($"Player count {playerCount}");
                return;
            }

            //Find naughty player
            var naughty = Random.Range(0, playerCount);

            //Set roles to all players
            for (var i = 0; i < playerCount; i++)
            {
                var playerData = PlayerManager.Instance.GetPlayer((PlayerIndex)naughty);

                playerData.PlayerRole = i == naughty ? PlayerRole.Naughty : PlayerRole.Saint;
                playerData.Controller.Kill();

            }
        }
    }
}
