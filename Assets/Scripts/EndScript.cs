using UnityEngine;

public class EndScript : MonoBehaviour
{
    private SceneScript scene;

    void Awake()
    {
        scene = Object.FindAnyObjectByType<SceneScript>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            scene.ChangeScene("MainMenuScene");
        }
    }
}
