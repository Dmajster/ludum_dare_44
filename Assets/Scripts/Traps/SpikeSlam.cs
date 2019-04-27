using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample {
    public class SpikeSlam : MonoBehaviour {
        public HoverButton button;
        private void Start() {
            if (button != null) {
                button.onButtonDown.AddListener(OnButtonDown);
            }
        }
        private void OnButtonDown(Hand hand) {
            var anim = gameObject.GetComponent<Animation>();
            if (anim.isPlaying) {
                anim.Stop();
            } else {
                anim.Play();
            }
        }
    }

}
