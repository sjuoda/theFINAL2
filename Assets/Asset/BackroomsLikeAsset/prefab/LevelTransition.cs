using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LevelTransition : MonoBehaviour
{
    public string nextSceneName;
    public Image fadePanel;
    public TextMeshProUGUI levelCompleteText;
    public float fadeDuration = 1.5f;
    public float waitAfterCompleteText = 2.0f;
    public AudioFadeController audioFadeController;

    private bool hasTriggered = false;

    void Start()
    {
        // Reset the fade panel to transparent at the start
        if (fadePanel != null)
        {
            Color resetColor = fadePanel.color;
            resetColor.a = 0;
            fadePanel.color = resetColor;
            Debug.Log("Fade panel reset to transparent.");
        }

        // Reset the level complete text visibility
        if (levelCompleteText != null)
        {
            levelCompleteText.alpha = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;  // Set the flag immediately
            Debug.Log("Transition Triggered.");
            StartCoroutine(FadeShowCompleteAndLoad());
        }
    }

    private IEnumerator FadeShowCompleteAndLoad()
    {
        // Start fading out the music
        if (audioFadeController != null)
        {
            StartCoroutine(audioFadeController.FadeOut());
        }

        // Fade the screen to black
        float elapsed = 0f;
        Color color = fadePanel.color;
        color.a = 0;
        fadePanel.color = color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, elapsed / fadeDuration); // Smooth transition
            fadePanel.color = new Color(0, 0, 0, alpha); // Full black with changing alpha
            yield return null;
        }

        // Ensure the panel is fully black at the end
        fadePanel.color = new Color(0, 0, 0, 1);

        // Show "Level Complete!" after fade
        levelCompleteText.alpha = 1f;
        Debug.Log("Level Complete!");

        // Wait after text
        yield return new WaitForSeconds(waitAfterCompleteText);

        // Check if the scene name is set correctly
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log("Loading Next Scene: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set. Please check the inspector.");
        }
    }
}
