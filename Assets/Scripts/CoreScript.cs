using UnityEngine;

public class CoreScript : MonoBehaviour
{
    public float scrollSpeed;

    //Rock Obstacle Refs
    public float rockSpawnRate;
    private float rockSpawnTime;

    void Awake()
    {
        Screen.SetResolution(400, 800, false);
    }

    void Update()
    {
        RockSpawning();
    }

    public void EndlessScroll(Rigidbody2D rigidbody)
    {
        rigidbody.linearVelocityY = 0.0f - scrollSpeed;
    }

    void RockSpawning()
    {
        rockSpawnTime = Time.deltaTime;
        if (rockSpawnTime == rockSpawnRate)
        {
            rockSpawnTime -= rockSpawnRate;

        }
    }
}
