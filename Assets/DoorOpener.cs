using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Vector3 openOffset = new Vector3(2f, 0f, 0f); // Slide 2 units to the right
    private bool isOpen = false;

    public void OpenDoor()
    {
        if (!isOpen)
        {
            transform.position += openOffset;
            isOpen = true;
        }
    }
}