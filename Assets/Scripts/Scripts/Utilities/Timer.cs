using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main.Scripts.Utilities
{
    public class Timer : MonoBehaviour
    {
        public float timeLeft = 10.0f;

        [SerializeField] TextMeshProUGUI timerUI;

        private void Start()
        {
            timeLeft += 1;
        }

        public void RunTimer()
        {
            timeLeft -= Time.deltaTime;
            timerUI.text = "Time Left: " + Mathf.Round(timeLeft);

            var minutes = Mathf.FloorToInt(timeLeft / 60);
            var seconds = Mathf.FloorToInt(timeLeft % 60);

            timerUI.text = String.Format("{0:00}:{1:00} ", minutes, seconds);

            if (timeLeft < 0)
            {
                timerUI.text = "00:00";
                SceneManager.LoadScene("Game Over");
            }
        }
    }
}