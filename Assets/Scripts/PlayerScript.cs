using UnityEngine;

public class PlayerScript : MonoBehaviour
{

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

    //TEMPORARY, THIS SHOULD NOT BE HERE PERMANENTALY
    public float scrollSpeed;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        MovementUpdate();
    }

    void MovementUpdate()
    {
        player.linearVelocityY = 0.0f - scrollSpeed;
        player.transform.position += transform.up * currentSpeed * Time.deltaTime;
        player.transform.Rotate(new Vector3(0, 0, currentRotation) * Time.deltaTime);

        //Forward Movement
        if (Input.GetKeyDown(forwardInput))
        {
            currentSpeed += forwardSpeed;
        }

        if (Input.GetKeyUp(forwardInput))
        {
            currentSpeed -= forwardSpeed;
        }

        //Backward Movement
        if (Input.GetKeyDown(backwardInput))
        {
            currentSpeed -= backwardSpeed;
        }

        if (Input.GetKeyUp(backwardInput))
        {
            currentSpeed += backwardSpeed;
        }

        //Left Turn
        if (Input.GetKeyDown(turnLeftInput))
        {
            currentRotation += turnSpeed;
        }

        if (Input.GetKeyUp(turnLeftInput))
        {
            currentRotation -= turnSpeed;
        }

        //Right Turn
        if (Input.GetKeyDown(turnRightInput))
        {
            currentRotation -= turnSpeed;
        }

        if (Input.GetKeyUp(turnRightInput))
        {
            currentRotation += turnSpeed;
        }
    }
}
