using UnityEngine;
using System.Collections;

public class AudioFadeController : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeDuration = 2f;
    public float maxVolume = 0.1f;  // Set your desired max volume here

    private void Start()
    {
        // Fade in at start
        audioSource.volume = 0f;
        audioSource.Play();
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Clamp01((elapsed / fadeDuration) * maxVolume);
            yield return null;
        }

        // Ensure final volume is set
        audioSource.volume = maxVolume;
    }

    public IEnumerator FadeOut()
    {
        float startVolume = audioSource.volume;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, elapsed / fadeDuration);
            yield return null;
        }

        audioSource.Stop();
    }
}
