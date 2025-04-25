using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneStartFadeIn : MonoBehaviour
{
    public Image fadePanel;      // Drag your FadePanel here
    public float fadeDuration = 2f;  // How many seconds to fade

    private void Start()
    {
        if (fadePanel != null)
        {
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        Color panelColor = fadePanel.color;
        panelColor.a = 1f;               // Start fully opaque (black)
        fadePanel.color = panelColor;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadePanel.color = new Color(panelColor.r, panelColor.g, panelColor.b, alpha);
            yield return null;
        }

        // Make sure it's fully transparent at the end
        panelColor.a = 0f;
        fadePanel.color = panelColor;
    }
}
