using UnityEngine;

namespace Assets.Scenes
{
    public class CameraManager : MonoBehaviour
    {
        public Camera Camera1;
        public Camera Camera2;

        private void Start()
        {
            Camera1.rect = new Rect(new Vector2(0, 0), new Vector2(1, 0.5f));
            Camera2.rect = new Rect(new Vector2(0, 0.5f), new Vector2(1, 0.5f));
        }

        private void Update()
        {

        }
    }
}
