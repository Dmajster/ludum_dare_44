using System.Collections;
using UnityEngine;

namespace Assets
{
    public class BridgeDestroy : MonoBehaviour
    {
        public GameObject PlankLeft;
        public GameObject PlankRight;

        public IEnumerator Start()
        {
            yield return new WaitForSeconds(5);
            DestroyPlank();
        }

        public void DestroyPlank()
        {
            PlankLeft.transform.parent = null;
            PlankRight.transform.parent = null;
            PlankLeft.GetComponent<Rigidbody>().isKinematic = false;
            PlankRight.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
