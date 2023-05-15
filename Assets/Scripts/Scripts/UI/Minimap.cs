using UnityEngine;

namespace _Main.Scripts.UI
{
    public class Minimap : MonoBehaviour
    {

        public Transform playerTransform;

        private void LateUpdate() //Se actualiza después de que se mueve el player
        {
            Vector3 newPosition = playerTransform.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
        }
    }
}
