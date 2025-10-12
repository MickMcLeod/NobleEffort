using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        if (sceneName == "MainMenuScene")
        {
            SceneManager.LoadScene("MainMenuScene");
        }
        else if (sceneName == "FirstTransitionScene")
        {
            SceneManager.LoadScene("FirstTransitionScene");
        }
        else if (sceneName == "GameScene")
        {
            SceneManager.LoadScene("GameScene");
        }
        else if (sceneName == "EndScene")
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
