using UnityEngine;

public class TransitionScript : MonoBehaviour
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
            scene.ChangeScene("GameScene");
        }
    }
}
