using UnityEngine;

public class CoreScript : MonoBehaviour
{
    public float scrollSpeed;

    //Rock Obstacle Refs
    public GameObject rock;
    public float rockSpawnRate;
    public float rockMinimumSize;
    public float rockMaximumSize;
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
        rockSpawnTime += Time.deltaTime;
        if (rockSpawnTime >= rockSpawnRate)
        {
            rockSpawnTime -= rockSpawnRate;
            Instantiate(rock, new Vector3(Random.Range(-2.0f, 2.0f), 6.0f, 0.0f), Quaternion.identity);
        }
    }
}
