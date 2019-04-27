using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample {
    public enum FlingVector {
        kUp,
        kDown,
        kLeft,
        kRight
    }
    public class ButtonFlingObject : MonoBehaviour {
        public HoverButton hoverButton;
        public FlingVector FlingVectorEnum;
        public GameObject prefab;
        public float ThrustAmmount = 1.0f;
        public float TimeAlive = 10.0f;

        private void Start() {
            if (hoverButton != null) {
                hoverButton.onButtonDown.AddListener(OnButtonDown);
            }
        }

        private void OnButtonDown(Hand hand) {
            GameObject obj = GameObject.Instantiate<GameObject>(prefab);
            StartCoroutine(FlingObject(obj));
            Destroy(obj, TimeAlive);
        }

        private IEnumerator FlingObject(GameObject obj) {
            obj.transform.position = this.transform.position;
            Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            float startTime = Time.time;
            float overTime = 0.5f;
            float endTime = startTime + overTime;

            while (Time.time < endTime) {
                switch (FlingVectorEnum) {
                    case FlingVector.kUp:
                        rigidbody.AddForce(Vector3.up * ThrustAmmount * Time.deltaTime, ForceMode.Impulse);
                        break;
                    case FlingVector.kDown:
                        rigidbody.AddForce(Vector3.down * ThrustAmmount * Time.deltaTime, ForceMode.Impulse);
                        break;
                    case FlingVector.kLeft:
                        rigidbody.AddForce(Vector3.left * ThrustAmmount * Time.deltaTime, ForceMode.Impulse);
                        break;
                    case FlingVector.kRight:
                        rigidbody.AddForce(Vector3.right * ThrustAmmount * Time.deltaTime, ForceMode.Impulse);
                        break;
                }
                yield return null;
            }
        }
    }
}