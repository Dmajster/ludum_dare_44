using Assets.Scripts.Player;
using UnityEngine;

namespace Assets {
    public class DeathZone : MonoBehaviour {
        private void OnTriggerEnter(Collider collider) {
            if (PlayerManager.Instance.Players != null) {
                var playerData = PlayerManager.Instance.GetPlayer(collider.gameObject);
                playerData?.Controller?.Kill();
            }
        }
    }
}
