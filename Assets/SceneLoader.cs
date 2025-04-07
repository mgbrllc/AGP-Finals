using UnityEngine;
using UnityEngine.SceneManagement; // Required to load scenes

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}