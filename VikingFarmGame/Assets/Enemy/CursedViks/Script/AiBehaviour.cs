using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviour : MonoBehaviour
{
    public Transform Player;
    public float MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;
    public int MinDistance = 2;
    //public Transform Environment;
    //public bool isOncommand;
    private Follow follow;
    //public Going going;
    //public LNwaypoints LN;

    private Animator myAnimator;
    private CharacterController cc;
    bool isGrounded = true;

    RaycastHit rayHit;
    


    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        follow = GetComponent<Follow>();
        follow.enabled = false;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);

        if (Physics.Raycast(cc.bounds.center, Vector3.down, cc.bounds.extents.y + 0.2f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (!isGrounded)
        {
            transform.Translate(new Vector3(0f, -10f, 0f) * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            myAnimator.SetBool("isRunning", true);
            /*if (!follow.enabled)
            {
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;

                myAnimator.SetBool("isRunning", true);
            }*/
        }
        else
        {
            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                myAnimator.SetBool("isRunning", false);
                /*if (!follow.enabled)
                {
                    myAnimator.SetBool("isRunning", false);
                }*/
            }
        }

        if (Vector3.Distance(transform.position, Player.position) <= MinDistance)
        {
            myAnimator.SetBool("isScared", true);
            /*if (!follow.enabled)
            {

                myAnimator.SetBool("isScared", true);
            }*/
        }
        else
        {
            //if (!follow.enabled)
            {

                myAnimator.SetBool("isScared", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {

            follow.enabled = !follow.enabled;
            follow.OnCommand = true;


        }

        /*
        if (Physics.Linecast(transform.position, Player.position))
        {

            if (rayHit.distance < jumpDist)
            {

                myAnimator.SetBool("isJumping", true);

            }
            else
            {
                myAnimator.SetBool("isJumping", false);
            }
        }
        */
    }
}
