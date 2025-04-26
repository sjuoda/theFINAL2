using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("lvl2"); // Replace with your Level 1 scene name
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game"); // Shows in editor (for testing)
        Application.Quit();     // Actually quits the game in a built version
    }
}
