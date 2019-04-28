using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody), typeof(GamePadState))]
    public class PlayerController : MonoBehaviour
    {
        public GamePadState State;
        public GamePadState PrevState;

        public PlayerIndex PlayerIndex;

        public Camera MovementCamera;

        public Rigidbody Rigidbody;

        public float StrafingSpeed;
        public float GravityStrength;
        public float JumpStrength;

        public bool CanJump;

        public float Gravity;

        public Vector3 StrafeTarget;
        public Vector3 Strafe;

        public AnimationCurve ThumbstickCurve;

        public GameObject VictimHat;

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();

            Debug.Log(transform.localScale.y);
        }

        public void SetVictimHat()
        {
            VictimHat.transform.SetParent(gameObject.transform);
        }

        private void FixedUpdate()
        {
            var movement = Vector3.zero;

            PrevState = State;
            State = GamePad.GetState(PlayerIndex);


            var rightVector = MovementCamera.transform.right;
            var forwardVector = Vector3.Cross(rightVector, Vector3.up);

            var thumbStick = new Vector2(State.ThumbSticks.Left.X, State.ThumbSticks.Left.Y);

            StrafeTarget = forwardVector * thumbStick.y +
                            rightVector * thumbStick.x;

            StrafeTarget *= ThumbstickCurve.Evaluate(StrafeTarget.magnitude * StrafingSpeed);
            StrafeTarget *= Time.deltaTime;

            Strafe = Vector3.Lerp(Strafe, StrafeTarget, 0.5f);

            movement += Strafe;

            CanJump = Physics.Raycast(transform.position, Vector3.down, transform.localScale.y + 0.01f);
            Debug.DrawRay(transform.position, Vector3.down * (transform.localScale.y + 0.001f));

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


            if (State.Buttons.B == ButtonState.Pressed)
            {
                Kill();
            }

        }

        public void Kill()
        {
            RespawnManager.Instance.Respawn(PlayerIndex);
        }

        public void Spawn(int index)
        {
            RespawnManager.Instance.Spawn(PlayerIndex, index);
        }
    }
}