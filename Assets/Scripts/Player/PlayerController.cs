using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.Player {
    [RequireComponent(typeof(Rigidbody), typeof(GamePadState))]
    public class PlayerController : MonoBehaviour {
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

        public IPlayerInput Input;

        public GameObject VictimHat;

        private void Start() {
            Rigidbody = GetComponent<Rigidbody>();

            Debug.Log(transform.localScale.y);
        }

        public void SetVictimHat() {
            VictimHat.transform.SetParent(gameObject.transform);
        }

        private void FixedUpdate() {
            if (transform.position.y < 0.4) {
                Kill();
            }
            var movement = Vector3.zero;
            var rightVector = MovementCamera.transform.right;
            var forwardVector = Vector3.Cross(rightVector, Vector3.up);

            StrafeTarget = forwardVector * Input.Vertical +
                            rightVector * Input.Horizontal;

            StrafeTarget *= ThumbstickCurve.Evaluate(StrafeTarget.magnitude * StrafingSpeed);
            StrafeTarget *= Time.deltaTime;

            Strafe = Vector3.Lerp(Strafe, StrafeTarget, 0.5f);

            movement += Strafe;

            CanJump = Physics.Raycast(transform.position, Vector3.down, transform.localScale.y + 0.01f);
            Debug.DrawRay(transform.position, Vector3.down * (transform.localScale.y + 0.001f));

            if (CanJump) {
                Gravity = 0;

                if (Input.Jumping) {
                    Gravity = JumpStrength * Time.deltaTime;
                }
            } else {
                Gravity += GravityStrength * Time.deltaTime;
            }

            movement += new Vector3(0, Gravity, 0);
            Rigidbody.transform.position += movement;
        }

        public void Kill() {
            var playerData = PlayerManager.Instance.GetPlayer(gameObject);

            if (playerData.LifesLeft > 0) {
                playerData.LifesLeft--;
                RespawnManager.Instance.Respawn(gameObject);
            } else {
                playerData.PlayerStatus = PlayerStatus.Dead;
                gameObject.SetActive(false);
            }
        }

        public void Spawn(int index) {
            RespawnManager.Instance.Spawn(gameObject, index);
        }
    }
}