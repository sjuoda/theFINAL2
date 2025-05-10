using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public float fadeDuration = 2.0f;

    void Start()
    {
        // Get the Audio Source on the same GameObject
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(FadeInMusic());
    }

    private System.Collections.IEnumerator FadeInMusic()
    {
        audioSource.volume = 0;
        float elapsed = 0;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, 0.02f, elapsed / fadeDuration); // Target volume is 0.5
            yield return null;
        }

        audioSource.volume = 0.02f;
    }
}
