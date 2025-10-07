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

    private bool losing = false;
    private bool stuck = false;

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
        if (losing == true)
        {
            player.linearVelocityY = 0.0f;
        }
        else if (stuck == true)
        {
            core.EndlessScroll(player);
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
        if (Input.GetKeyDown(forwardInput) && (losing == false))
        {
            currentSpeed += forwardSpeed;
        }

        if (Input.GetKeyUp(forwardInput) && (losing == false))
        {
            currentSpeed -= forwardSpeed;
        }

        //Backward Movement
        if (Input.GetKeyDown(backwardInput) && (losing == false))
        {
            currentSpeed -= backwardSpeed;
        }

        if (Input.GetKeyUp(backwardInput) && (losing == false))
        {
            currentSpeed += backwardSpeed;
        }

        //Left Turn
        if (Input.GetKeyDown(turnLeftInput) && (losing == false))
        {
            currentRotation += turnSpeed;
        }

        if (Input.GetKeyUp(turnLeftInput) && (losing == false))
        {
            currentRotation -= turnSpeed;
        }

        //Right Turn
        if (Input.GetKeyDown(turnRightInput) && (losing == false))
        {
            currentRotation -= turnSpeed;
        }

        if (Input.GetKeyUp(turnRightInput) && (losing == false))
        {
            currentRotation += turnSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LossZone"))
        {
            losing = true;
        }

        if (other.CompareTag("Rock"))
        {
            stuck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LossZone"))
        {
            losing = false;
        }

        if (other.CompareTag("Rock"))
        {
            stuck = false;
        }
    }
}
