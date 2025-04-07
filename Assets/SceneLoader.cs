using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f; // ✅ Unpause before loading the scene
        SceneManager.LoadScene(sceneName);
    }
}
