using UnityEngine;
using TMPro;

public class LetterCollector : MonoBehaviour
{
    public int lettersCollected = 0;
    public int totalLetters = 4;
    public TextMeshProUGUI completionMessage;
    public DoorOpener door;

    public TextMeshProUGUI[] letterTexts; // 4 slots for M, A, Z, E (in that order)
    public AudioSource pickupSound;  // Add this

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Letter"))
        {
            LetterIdentity letter = other.GetComponent<LetterIdentity>();
            string pickedLetter = letter.letterValue.ToUpper();

            int index = GetLetterIndex(pickedLetter);

            if (index != -1 && letterTexts[index].text == "")
            {
                letterTexts[index].text = pickedLetter;
                lettersCollected++;

                // Play pickup sound
                pickupSound.Play();
            }

            Destroy(other.gameObject);

            if (lettersCollected >= totalLetters)
            {
                door.OpenDoor();
                completionMessage.text = "MAZE COMPLETE – DOOR OPEN";
            }
        }
    }

    int GetLetterIndex(string letter)
    {
        switch (letter)
        {
            case "M": return 0;
            case "A": return 1;
            case "Z": return 2;
            case "E": return 3;
            default: return -1;
        }
    }
}
