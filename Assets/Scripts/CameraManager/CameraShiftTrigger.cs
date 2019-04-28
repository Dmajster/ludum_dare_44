using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.CameraManager {
    public class CameraShiftTrigger : MonoBehaviour {
        private void OnTriggerExit(Collider collider) {
            if (PlayerManager.Instance.GetPlayer(collider.gameObject) == null) {
                return;
            }

            var isMovingForward =
                Vector3.Project(collider.gameObject.transform.position - transform.position, transform.right).x < 0;

            if (isMovingForward) {
                CameraManager.Instance.ShiftNext();
            } else {
                CameraManager.Instance.ShiftPrevious();
            }
        }
    }
}