using UnityEngine;

public class GizmoFling : MonoBehaviour {
    public float explosionRadius = 5.0f;

    void OnDrawGizmos() {
        Gizmos.color = new Color(1, 0, 0, 1F);
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}