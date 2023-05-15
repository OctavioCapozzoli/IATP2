using UnityEngine;

namespace _Main.Scripts.Utilities
{
    public class GameManager : MonoBehaviour
    {
        private Timer _timer;

        private void Awake()
        {
            _timer = GetComponent<Timer>();
        }
        private void Update()
        {
            _timer.RunTimer();
        }
    }
}
