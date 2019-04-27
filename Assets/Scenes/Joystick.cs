using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scenes
{

    [RequireComponent(typeof(CharacterController),typeof(GamePadState))]
    public class Joystick : MonoBehaviour
    {
        public GamePadState State;
        public GamePadState PrevState;


        public CharacterController CharacterController;

        public PlayerIndex PlayerIndex;

        public Vector3 Strafing;

        public float StrafingSpeed = 0.1f;
        public float GravityStrength = -9.81f;
        public float JumpStrength = 20f;

        public float Gravity;

        private void Start()
        {
            CharacterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            var movement = Vector3.zero;

            PrevState = State;
            State = GamePad.GetState(PlayerIndex);



            var strafingNormal = new Vector3(State.ThumbSticks.Left.X, 0, State.ThumbSticks.Left.Y);
            Strafing = strafingNormal * StrafingSpeed * Time.deltaTime;

            movement += Strafing;

            if (CharacterController.isGrounded)
            {
                Gravity = 0;

                if (State.Buttons.A == ButtonState.Pressed)
                {
                    Gravity = JumpStrength * Time.deltaTime;
                }
            }
            else
            {
                Gravity += GravityStrength * Time.deltaTime;
                movement += new Vector3(0, Gravity, 0);
            }


            CharacterController.Move(movement);
            
        }
    }
}
