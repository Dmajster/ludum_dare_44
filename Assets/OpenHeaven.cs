using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample {
    public class OpenHeaven : MonoBehaviour {
        public HoverButton hoverButton;
        public GameObject GateLeft;
        public GameObject GateRight;
        public bool IsHeavenOpen = false;

        private void Start() {
            GateLeft.GetComponent<Animator>().enabled = false;
            GateRight.GetComponent<Animator>().enabled = false;

            if (hoverButton != null) {
                hoverButton.onButtonDown.AddListener(OnButtonDown);
            }
        }

        private void OnButtonDown(Hand hand) {
            if (!IsHeavenOpen) {
                GateLeft.GetComponent<Animator>().enabled = true;
                GateRight.GetComponent<Animator>().enabled = true;

                var animLeft = GateLeft.GetComponent<Animator>();
                var animRight = GateRight.GetComponent<Animator>();

                animRight.Play(0);
                animLeft.Play(1);
                IsHeavenOpen = true;
            }
        }

    }
}