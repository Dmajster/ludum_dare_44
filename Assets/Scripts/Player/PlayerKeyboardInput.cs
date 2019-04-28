using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerKeyboardInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public bool Jumping => Input.GetButton("Jump");
    }
}
