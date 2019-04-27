using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player {
    public class WorldController : MonoBehaviour {
        // Start is called before the first frame update
        void Start() {
            GameOverlord.Instance.InitGameOverlord();
        }

        // Update is called once per frame
        void Update() {

        }
    }
}