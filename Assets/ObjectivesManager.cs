using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectivesManager : MonoBehaviour
{
    public string nextSceneName = "lvl1"; // Change this to your actual first level name

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
