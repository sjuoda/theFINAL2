using UnityEngine;
using TMPro;

public class LetterCollector : MonoBehaviour
{
    public int lettersCollected = 0;
    public int totalLetters = 4;
    public TextMeshProUGUI completionMessage;
    public DoorOpener door;

    public TextMeshProUGUI[] letterTexts; // 4 slots for M, A, Z, E (in that order)

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Letter"))
        {
            LetterIdentity letter = other.GetComponent<LetterIdentity>();
            string pickedLetter = letter.letterValue.ToUpper(); // just in case

            // Determine correct index based on letter
            int index = GetLetterIndex(pickedLetter);

            if (index != -1 && letterTexts[index].text == "")
            {
                letterTexts[index].text = pickedLetter;
                lettersCollected++;
            }

            Destroy(other.gameObject);

            if (lettersCollected >= totalLetters)
            {
                door.OpenDoor();
                completionMessage.text = "MAZE COMPLETE – DOOR OPEN";
            }
        }
    }

    // Helper method to map letters to UI positions
    int GetLetterIndex(string letter)
    {
        switch (letter)
        {
            case "M": return 0;
            case "A": return 1;
            case "Z": return 2;
            case "E": return 3;
            default: return -1; // Invalid letter
        }
    }
}