using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ind : MonoBehaviour
{
    public float scaleAmount = 0.1f; // Amount to scale the object
    public float dwindlingSpeed = 1f; // Speed of the dwindling animation
    public float dwindlingIntensity = 0.5f; // Intensity of the dwindling motion

    private Vector3 originalScale; // Original scale of the object

    void Start()
    {
        // Store the original scale of the object
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Calculate the scale factor using a sine wave
        float scaleFactor = 1f + Mathf.Sin(Time.time * dwindlingSpeed) * dwindlingIntensity;

        // Apply the scale animation
        transform.localScale = originalScale + Vector3.right * Mathf.Sin(Time.time * dwindlingSpeed) * scaleAmount;
    }
}
