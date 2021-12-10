using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float jumpSpeed = 10f;
    public float gravity = 20f;
    public float rotateSpeed = 3f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterAnimations playerAnimation;

    [HideInInspector]
    public bool canMove = true;

    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    Vector2 rotation = Vector2.zero;

    public Joystick joystick;
    public Joystick rJoystick;

    // Use this for initialization
    void Start()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (moveDirection != Vector3.zero)
        {
            playerAnimation.Walk(true);
        }
        else
        {
            playerAnimation.Walk(false);
        }
        
        if (controller.isGrounded)
        {
            
            if (Input.GetButton("Jump"))
            {
                //playerAnimation.Jump(true);
                moveDirection.y = jumpSpeed;
            }
            else
            {
                //playerAnimation.Jump(false);
            }



        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

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




        /*if (Input.GetAxis("Horizontal") != 0f)
        {
            playerAnimation.Walk(true);
        }
        else
        {
            playerAnimation.Walk(false);
        }*/

        /*if (Input.GetAxis("Horizontal") != 0f)
        {
            playerAnimation.Right(true);
        }
        else
        {
            playerAnimation.Right(false);
        }

        /*if (Input.GetAxis("-Vertical") != 0f)
        {
            playerAnimation.Left(true);
        }
        else
        {
            playerAnimation.Left(false);
        }*/

        //this.transform.Translate(Input.GetAxis("Horizontal"), 0, 0);

    }
    public void Move()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        //float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
        //float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
        float curSpeedX = canMove ? speed * joystick.Vertical : 0;
        float curSpeedY = canMove ? speed * joystick.Horizontal : 0;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);


    }
}
