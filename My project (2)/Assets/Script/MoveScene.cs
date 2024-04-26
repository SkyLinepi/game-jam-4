using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void LoadScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Close()
    {
        // Close the game
        Application.Quit();
    }
}
