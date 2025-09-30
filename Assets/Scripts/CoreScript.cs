using UnityEngine;

public class CoreScript : MonoBehaviour
{
    public float scrollSpeed;

    void Awake()
    {
        Screen.SetResolution(480, 1080, false);
    }

    public void EndlessScroll(Rigidbody2D rigidbody)
    {
        rigidbody.linearVelocityY = 0.0f - scrollSpeed;
    }
}
