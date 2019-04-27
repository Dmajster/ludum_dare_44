using UnityEngine;

namespace Assets.Scripts.CameraManager
{
    public class CameraShiftTrigger : MonoBehaviour
    {
        private void OnTriggerExit(Collider collider)
        {
            var isMovingForward =
                Vector3.Project(collider.gameObject.transform.position - transform.position, transform.right).x < 0;

            if (isMovingForward)
            {
                CameraManager.Instance.ShiftNext();
            }
            else
            {
                CameraManager.Instance.ShiftPrevious();
            }
        }
    }
}