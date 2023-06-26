using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevelTrigger : MonoBehaviour
{
    [SerializeField] GameObject playerGo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(AsyncSceneLoader());
        }
    }

    IEnumerator AsyncSceneLoader()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BossScene", LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(playerGo, SceneManager.GetSceneByName("BossScene"));
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
