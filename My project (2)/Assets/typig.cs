using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class typig : MonoBehaviour
{
    public TMP_Text textComponent; // Reference to the TextMesh Pro Text component
    public string textToType; // The string to be typed out
    public float typingSpeed = 0.05f; // Speed at which characters are typed out (in seconds)

    private Coroutine typingCoroutine; // Coroutine for typing out the text

    void Start()
    {
        // Start typing out the text
        typingCoroutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        // Ensure the text component is not null
        if (textComponent == null)
        {
            Debug.LogError("Text component reference is missing!");
            yield break;
        }

        // Iterate through each character in the text
        for (int i = 0; i <= textToType.Length; i++)
        {
            // Get the substring up to the current character
            string partialText = textToType.Substring(0, i);

            // Set the text component's text to the partial text
            textComponent.text = partialText;

            // Wait for a short duration before typing the next character
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Call this method to stop the typing effect prematurely
    public void StopTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
    }
}
