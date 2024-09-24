using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function for the Play button to load the game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // Make sure the scene is added in Build Settings
    }

    // Function for the Settings button
    public void OpenSettings()
    {
        // You can add functionality here for a settings menu, or open a new scene
        Debug.Log("Settings button clicked");
    }

    // Function for the Quit button
    public void QuitGame()
    {
        Debug.Log("Quit button clicked");
        Application.Quit();  // This will work when the game is built, not in the editor
    }
}
