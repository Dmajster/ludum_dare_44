using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody),typeof(GamePadState))]
    public class PlayerController : MonoBehaviour
    {
        public GamePadState State;
        public GamePadState PrevState;

        public PlayerIndex PlayerIndex;

        public Vector3 Strafing;

        public Rigidbody Rigidbody;

        public float StrafingSpeed;
        public float GravityStrength;
        public float JumpStrength;

        public bool CanJump;

        public float Gravity;

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Rigidbody.isKinematic = true;
            
            Debug.Log(transform.localScale.y);
        }

        private void FixedUpdate()
        {
            var movement = Vector3.zero;

            PrevState = State;
            State = GamePad.GetState(PlayerIndex);



            var strafingNormal = new Vector3(State.ThumbSticks.Left.X, 0, State.ThumbSticks.Left.Y);
            Strafing = strafingNormal * StrafingSpeed * Time.deltaTime;

            movement += Strafing;

            CanJump = Physics.Raycast(transform.position, Vector3.down, transform.localScale.y + 0.01f);
            Debug.DrawRay(transform.position, Vector3.down * (transform.localScale.y + 0.001f ));

            if (CanJump)
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
            }

            movement += new Vector3(0, Gravity, 0);

            Rigidbody.transform.position += movement;
            
        }
    }
}
