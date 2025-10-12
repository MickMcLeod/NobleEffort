using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Windows;

public class PlayerScript : MonoBehaviour
{
    private CoreScript core;
    private SceneScript scene;

    public SpriteRenderer playerSprite;
    public Sprite p1Boat;
    public Sprite p2Boat;
    public Sprite p3Boat;
    public Sprite p4Boat;
    
    public Rigidbody2D player;

    private float currentSpeed;
    private float currentRotation;

    //public KeyCode forwardInput; (DEPRECATED)
    private bool forwardPressed;
    public float forwardSpeed;

    //public KeyCode backwardInput; (DEPRECATED)
    private bool backPressed;
    public float backwardSpeed;

    //public KeyCode turnLeftInput; (DEPRECATED)
    //public KeyCode turnRightInput; (DEPRECATED)
    private bool turnLeftPressed;
    private bool turnRightPressed;
    public float turnSpeed;

    private bool losing = false;
    private float maxGameOverTime;
    private float currentGameOverTime;
    private bool stuck = false;

    private void Awake()
    {
        core = Object.FindAnyObjectByType<CoreScript>();
        scene = Object.FindAnyObjectByType<SceneScript>();
    }

    void Start()
    {
        core.AddPlayer();
        switch (core.playerSpriteCount)
        {
            case 1:
                playerSprite.sprite = p1Boat;
                break;
            case 2:
                playerSprite.sprite = p2Boat;
                break;
            case 3:
                playerSprite.sprite = p3Boat;
                break;
            case 4:
                playerSprite.sprite = p4Boat;
                break;
        }
        maxGameOverTime = core.playerGameOverTime;
    }

    
    void Update()
    {
        if (losing == true)
        {
            player.linearVelocityY = 0.0f;
            currentGameOverTime += Time.deltaTime;
            if (currentGameOverTime >= maxGameOverTime)
            {
                Destroy(gameObject);
                core.RemovePlayer();
                if (core.playerCount == 0)
                {
                    scene.ChangeScene("EndScene");
                }
            }
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
        player.transform.position += currentSpeed * Time.deltaTime * transform.up;
        player.transform.Rotate(new Vector3(0, 0, currentRotation) * Time.deltaTime);

        /*Forward Movement (DEPRECATED)
        if (Input.GetKeyDown(forwardInput) && (losing == false))
        {
            currentSpeed += forwardSpeed;
        }

        if (Input.GetKeyUp(forwardInput) && (losing == false))
        {
            //currentSpeed -= forwardSpeed;
        } */

        /*Backward Movement (DEPRECATED)
        if (Input.GetKeyDown(backwardInput) && (losing == false))
        {
            currentSpeed -= backwardSpeed;
        }

        if (Input.GetKeyUp(backwardInput) && (losing == false))
        {
            currentSpeed += backwardSpeed;
        } */

        /*Left Turn (DEPRECATED)
        if (Input.GetKeyDown(turnLeftInput) && (losing == false))
        {
            currentRotation += turnSpeed;
        }

        if (Input.GetKeyUp(turnLeftInput) && (losing == false))
        {
            currentRotation -= turnSpeed;
        } */

        /*Right Turn (DEPRECATED)
        if (Input.GetKeyDown(turnRightInput) && (losing == false))
        {
            currentRotation -= turnSpeed;
        }

        if (Input.GetKeyUp(turnRightInput) && (losing == false))
        {
            currentRotation += turnSpeed;
        } */
    }

    void OnForward(InputValue value)
    {
        forwardPressed = value.isPressed;
        if ((forwardPressed == true) && (losing == false))
        {
            currentSpeed += forwardSpeed;
        }

        if ((forwardPressed == false) && (losing == false))
        {
            currentSpeed -= forwardSpeed;

        }
    }

    void OnBack(InputValue value)
    {
        backPressed = value.isPressed;
        if ((backPressed == true) && (losing == false))
        {
            currentSpeed -= backwardSpeed;
        }

        if ((backPressed == false) && (losing == false))
        {
            currentSpeed += backwardSpeed;
        }
    }

    void OnRotateLeft(InputValue value)
    {
        turnLeftPressed = value.isPressed;
        if ((turnLeftPressed == true) && (losing == false))
        {
            currentRotation += turnSpeed;
        }

        if ((turnLeftPressed == false) && (losing == false))
        {
            currentRotation -= turnSpeed;
        }
    }

    void OnRotateRight(InputValue value)
    {
        turnRightPressed = value.isPressed;
        if ((turnRightPressed == true) && (losing == false))
        {
            currentRotation -= turnSpeed;
        }

        if ((turnRightPressed == false) && (losing == false))
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
            currentGameOverTime = 0.0f;
        }

        if (other.CompareTag("Rock"))
        {
            stuck = false;
        }
    }
}
