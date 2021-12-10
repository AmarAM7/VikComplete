using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 2f;
    
    public float gravity = 20.0f;
    public float jumpHeight = 10;
    private float _directionY;


    private CharacterController _controller;
    //bool isGrounded = true;

    private Animator myAnimator;
    private Vector3 moveDirection = Vector3.zero;
    [HideInInspector]
    public bool canMove = true;

    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    Vector2 rotation = Vector2.zero;
    public GameObject pullString;
    public GameObject flatString;
    public GameObject crossHair;
    public AudioSource audioo;
    public GameObject bow;

    
    public Joystick joystick;
    public Joystick rJoystick;

    //Interaction components
    PlayerInteraction playerInteraction; 

    // Start is called before the first frame update
    void Start()
    {
        //Get movement components
        _controller = GetComponent<CharacterController>();
        myAnimator = GetComponent<Animator>();
        

        //Get interaction component
        playerInteraction = GetComponentInChildren<PlayerInteraction>();

        crossHair.SetActive(false);
        audioo = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Runs the function that handles all movement

        Move();

        if (moveDirection != Vector3.zero)
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }

        //Runs the function that handles all interaction
        Interact();


        //Debugging purposes only
        //Skip the time when the right square bracket is pressed
        if (Input.GetKey(KeyCode.RightBracket))
        {
            TimeManager.Instance.Tick();
        }

        if (_controller.isGrounded)
        {
            // We are grounded, so recalculate move direction based on axes
            

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpHeight;
            }

        }
        moveDirection.y -= gravity * Time.deltaTime;

        if (canMove)
        {
            //rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            //rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.y += rJoystick.Horizontal * lookSpeed;
            rotation.x += -rJoystick.Vertical * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);

            
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            audioo.Play();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            bow.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            bow.SetActive(false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            myAnimator.SetBool("isBowingAim", true);
            pullString.SetActive(true);
            flatString.SetActive(false);
            crossHair.SetActive(true);
        }
        else
        {
            myAnimator.SetBool("isBowingAim", false);
            pullString.SetActive(false);
            flatString.SetActive(true);
            crossHair.SetActive(false);
        }



    }
    public void Interact()
    {
        //Tool interaction
        if (Input.GetButtonDown("Fire1"))
        {
            //Interact
            playerInteraction.Interact();
            myAnimator.SetBool("isTooling", true);

        }
        else
        {
            myAnimator.SetBool("isTooling", false);
        }

        //Item interaction
        if (Input.GetButtonDown("Fire2"))
        {
            playerInteraction.ItemInteract();
            myAnimator.SetBool("isPickingup", true);
        }
        else
        {
            myAnimator.SetBool("isPickingup", false);
        }
    }

    /*public void Aim()
    {
        myAnimator.SetBool("isBowingAim", true);
        pullString.SetActive(true);
        flatString.SetActive(false);
        crossHair.SetActive(true);
    }
    public void NoAim()
    {
        myAnimator.SetBool("isBowingAim", false);
        pullString.SetActive(false);
        flatString.SetActive(true);
        crossHair.SetActive(false);
    }*/

    public void Move()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = canMove ? Speed * joystick.Vertical : 0;
        float curSpeedY = canMove ? Speed * joystick.Horizontal : 0;
        //float curSpeedX = canMove ? Speed * (Input.GetAxis("Vertical")) : 0;
        //float curSpeedY = canMove ? Speed * (Input.GetAxis("Horizontal")) : 0;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Move the controller
        _controller.Move(moveDirection * Time.deltaTime);

        
    }
}
