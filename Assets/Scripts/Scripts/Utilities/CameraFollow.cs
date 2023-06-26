using UnityEngine;

namespace _Main.Scripts.Utilities
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] Vector3 offset;
        [SerializeField] Quaternion rotation;

        // Start is called before the first frame update
        void Start()
        {

            if (GameObject.FindWithTag("Player"))
            {
                Debug.Log("Spawneando acá");
                var playerGO = GameObject.FindWithTag("Player");
                target = playerGO.transform;
            }
        }

        void FixedUpdate()
        {
            if (target != null)
            {
                transform.position = target.position + offset;
                transform.rotation = rotation;
            }
        }

    }
}
