using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main.Scripts.UI
{
    public class MainMenu : MonoBehaviour
    {

        public void OnStartPlay()
        {
            SceneManager.LoadScene("Level_TEST");
        }

        public void OnQuitAplication()
        {
            Application.Quit();
        }
    }
}
