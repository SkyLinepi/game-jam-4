using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : MonoBehaviour
{
    // Reference to the Sprite Renderer component
    private SpriteRenderer spriteRenderer;

    // Public variable to control alpha value
    [Range(0f, 1f)]
    public float alpha = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Sprite Renderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if a Sprite Renderer component is attached
        if (spriteRenderer == null)
        {
            Debug.LogError("No Sprite Renderer component found on this GameObject!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Set the alpha value of the Sprite Renderer
        SetAlpha(alpha);
    }

    // Function to set the alpha value of the Sprite Renderer
    public void SetAlpha(float alphaValue)
    {
        // Ensure the alpha value is within the valid range (0 to 1)
        float clampedAlpha = Mathf.Clamp01(alphaValue);

        // Get the current color of the Sprite Renderer
        Color spriteColor = spriteRenderer.color;

        // Set the alpha value of the color
        spriteColor.a = clampedAlpha;

        // Assign the modified color back to the Sprite Renderer
        spriteRenderer.color = spriteColor;
    }
}
