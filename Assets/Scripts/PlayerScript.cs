using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private CoreScript core;

    public Rigidbody2D player;

    private float currentSpeed;
    private float currentRotation;

    public KeyCode forwardInput;
    public float forwardSpeed;

    public KeyCode backwardInput;
    public float backwardSpeed;

    public KeyCode turnLeftInput;
    public KeyCode turnRightInput;
    public float turnSpeed;

    private bool Losing = false;

    private void Awake()
    {
        core = Object.FindAnyObjectByType<CoreScript>();
    }

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Losing == true)
        {
            player.linearVelocityY = 0.0f;
        }
        else
        {
            core.EndlessScroll(player);
            MovementUpdate();
        }
    }

    void MovementUpdate()
    {
        player.transform.position += transform.up * currentSpeed * Time.deltaTime;
        player.transform.Rotate(new Vector3(0, 0, currentRotation) * Time.deltaTime);

        //Forward Movement
        if (Input.GetKeyDown(forwardInput) && (Losing == false))
        {
            currentSpeed += forwardSpeed;
        }

        if (Input.GetKeyUp(forwardInput) && (Losing == false))
        {
            currentSpeed -= forwardSpeed;
        }

        //Backward Movement
        if (Input.GetKeyDown(backwardInput) && (Losing == false))
        {
            currentSpeed -= backwardSpeed;
        }

        if (Input.GetKeyUp(backwardInput) && (Losing == false))
        {
            currentSpeed += backwardSpeed;
        }

        //Left Turn
        if (Input.GetKeyDown(turnLeftInput) && (Losing == false))
        {
            currentRotation += turnSpeed;
        }

        if (Input.GetKeyUp(turnLeftInput) && (Losing == false))
        {
            currentRotation -= turnSpeed;
        }

        //Right Turn
        if (Input.GetKeyDown(turnRightInput) && (Losing == false))
        {
            currentRotation -= turnSpeed;
        }

        if (Input.GetKeyUp(turnRightInput) && (Losing == false))
        {
            currentRotation += turnSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LossZone"))
        {
            Losing = true;
            Debug.Log("Entered LossZone");
        }
    }
}
