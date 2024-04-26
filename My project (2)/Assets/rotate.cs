using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation in degrees per second

    void Update()
    {
        // Rotate the object around the Z-axis continuously
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
