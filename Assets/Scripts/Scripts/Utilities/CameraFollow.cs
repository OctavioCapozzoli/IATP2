using UnityEngine;

namespace _Main.Scripts.Utilities
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] Vector3 offset;
        [SerializeField] Quaternion rotation;

        void FixedUpdate()
        {
            transform.position = target.position + offset;
            transform.rotation = rotation;
        }

    }
}
