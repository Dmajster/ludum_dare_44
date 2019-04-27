using System;
using UnityEngine;

namespace Assets.Scripts.CameraManager
{
    [Serializable]
    public class CameraShift
    {
        public Transform CameraOffset;
        public Collider Trigger;
    }
}
