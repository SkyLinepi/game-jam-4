using UnityEngine;

public class Breathing : MonoBehaviour
{
    public float scaleAmount = 0.1f; // Amount to scale the object
    public float breathingSpeed = 1f; // Speed of the breathing animation
    public float breathingIntensity = 0.5f; // Intensity of the breathing motion

    private Vector3 originalScale; // Original scale of the object

    void Start()
    {
        // Store the original scale of the object
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Calculate the scale factor using a sine wave
        float scaleFactor = 1f + Mathf.Sin(Time.time * breathingSpeed) * breathingIntensity;

        // Apply the scale animation
        transform.localScale = originalScale * scaleFactor;
    }
}
