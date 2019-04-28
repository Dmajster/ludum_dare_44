using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample {

    public class SwitchToGame : MonoBehaviour {
        public HoverButton hoverButton;

        private void Start() {
            if (hoverButton != null) {
                hoverButton.onButtonDown.AddListener(OnButtonDown);
            }
        }

        private void OnButtonDown(Hand hand) {
            SceneManager.LoadScene(1);
        }

    }
}