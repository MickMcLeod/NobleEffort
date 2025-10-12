using UnityEngine;

public class MenuScript : MonoBehaviour
{
    private SceneScript scene;

    void Awake()
    {
        Screen.SetResolution(1600, 800, false);
        scene = Object.FindAnyObjectByType<SceneScript>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            scene.ChangeScene("FirstTransitionScene");
        }
    }
}
