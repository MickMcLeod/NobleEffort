using UnityEngine;

public class RockScript : MonoBehaviour
{
    private CoreScript core;
    public Rigidbody2D rock;

    void Awake()
    {
        core = Object.FindAnyObjectByType<CoreScript>();
    }

    void Start()
    {
        transform.localScale = new Vector3(Random.Range(core.rockMinimumSize, core.rockMaximumSize), Random.Range(core.rockMinimumSize, core.rockMaximumSize), 0.0f);
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }

    void Update()
    {
        core.EndlessScroll(rock);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestroyZone"))
        {
            Destroy(gameObject);
        }
    }

}
