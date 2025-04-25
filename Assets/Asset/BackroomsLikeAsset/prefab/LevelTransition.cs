using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LevelTransition : MonoBehaviour
{
    public string nextSceneName = "Level 2";
    public Image fadePanel;
    public TextMeshProUGUI levelCompleteText;
    public float fadeDuration = 1.5f;
    public float waitAfterCompleteText = 2.0f;
    public AudioFadeController audioFadeController; // << Add this

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
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

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / fadeDuration);
            fadePanel.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // Show "Level Complete!" after fade
        levelCompleteText.alpha = 1f;

        // Wait after text
        yield return new WaitForSeconds(waitAfterCompleteText);

        // Load next scene
        SceneManager.LoadScene(nextSceneName);
    }
}