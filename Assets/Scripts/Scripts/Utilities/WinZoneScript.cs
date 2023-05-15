using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main.Scripts.Utilities
{
    public class WinZoneScript : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
