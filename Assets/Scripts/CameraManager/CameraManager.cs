using Assets.Scripts.Abstractions;
using Assets.Scripts.Player;
using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.CameraManager
{
    public class CameraManager : Singleton<CameraManager>
    {
        public Camera Camera;

        public float MinDistance = 0.5f;
        public float BorderModifier;

        public float DistanceModifer;

        public float DesiredDistance;
        public float CurrentDistance;

        public Vector3 TargetCenter;
        public Vector3 CurrentCenter;

        public CameraShift[] CameraShifts;
        public int CurrentCameraShift = 0;

        public Vector3 TargetEulerAngles;

        public void Update()
        {
            var center = Vector3.zero;
            var min = PlayerManager.Instance.Players[0].Instance.transform.position;
            var max = PlayerManager.Instance.Players[0].Instance.transform.position;

            foreach (var playerData in PlayerManager.Instance.Players)
            {
                var position = playerData.Instance.transform.position;

                center += position;

                if (position.x < min.x)
                {
                    min.x = position.x;
                }

                if (position.z < min.z)
                {
                    min.z = position.z;
                }

                if (position.x > max.x)
                {
                    max.x = position.x;
                }

                if (position.z > max.z)
                {
                    max.z = position.z;
                }
            }

            center /= PlayerManager.Instance.Players.Count;

            TargetCenter = center;
            CurrentCenter = Vector3.Slerp(CurrentCenter, TargetCenter, Time.deltaTime);

            transform.position = CurrentCenter;
            

            DesiredDistance = Mathf.Max(0.5f, Vector3.Distance(min, max) * DistanceModifer) + 2 * BorderModifier;

            CurrentDistance = Mathf.Lerp(CurrentDistance, DesiredDistance, Time.deltaTime);

            Camera.transform.position = transform.position + Camera.transform.forward * -CurrentDistance;

            Camera.transform.eulerAngles =
                Vector3.Slerp(Camera.transform.eulerAngles, TargetEulerAngles, Time.deltaTime);

            TargetEulerAngles = CameraShifts[CurrentCameraShift].CameraOffset.eulerAngles;
        }

        public void ShiftNext()
        {
            Debug.Log("Next Scene");
            CurrentCameraShift++;
            TargetEulerAngles = CameraShifts[CurrentCameraShift].CameraOffset.eulerAngles;
        }
        public void ShiftPrevious()
        {
            Debug.Log("Previous Scene");
            CurrentCameraShift--;
            TargetEulerAngles = CameraShifts[CurrentCameraShift].CameraOffset.eulerAngles;
        }
    }
}
