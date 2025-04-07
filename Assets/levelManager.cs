using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    // Load a scene by its build index or name
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // Optional: return to main menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Optional: quit the game
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}