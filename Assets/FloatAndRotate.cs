using UnityEngine;

public class FloatAndRotate : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 50f, 0f); // Rotate around Y axis
    public float floatSpeed = 1f; // Speed of floating
    public float floatHeight = 0.5f; // How high to float up and down

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Rotate the object
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);

        // Float the object up and down
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}