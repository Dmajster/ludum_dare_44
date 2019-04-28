using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample {
    public class ButtonControlCrane : MonoBehaviour {
        public HoverButton hoverButton;
        public GameObject CraneTop;

        private void Start() {
            if (hoverButton != null) {
                hoverButton.onButtonDown.AddListener(OnButtonDown);
            }
        }


        private void OnButtonDown(Hand hand) {
            var anim = CraneTop.GetComponent<Animator>();
            anim.Play("crane_rotate");
        }

    }
}