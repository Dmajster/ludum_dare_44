using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace Valve.VR.InteractionSystem.Sample {

    public class SwitchToGame : MonoBehaviour {
        public HoverButton hoverButton;
        public List<GameObject> DisableGameObjects = new List<GameObject>();

        private void Start() {
            if (hoverButton != null) {
                hoverButton.onButtonDown.AddListener(OnButtonDown);
            }
        }

        private void OnButtonDown(Hand hand) {
            //foreach (var item in DisableGameObjects) {
            //    item.SetActive(false);
            //}
            SceneManager.LoadScene(1);
        }

    }
}