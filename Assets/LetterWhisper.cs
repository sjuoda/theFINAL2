using UnityEngine;

public class LetterWhisper : MonoBehaviour
{
    private AudioSource whisper;

    void Start()
    {
        whisper = GetComponent<AudioSource>();
        whisper.Play();  // Start playing when the game starts
    }
}
