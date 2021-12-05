using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    public Transform Player;
    public float MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;
    public int MinDistance = 2;
    //public Transform Environment;
    //public bool isOncommand;
    //private Follow follow;
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
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            myAnimator.SetBool("isWorking", true);
        }
        else
        {
            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                myAnimator.SetBool("isWorking", false);
            }
        }

        if (Vector3.Distance(transform.position, Player.position) <= MinDistance)
        {
            myAnimator.SetBool("isScared", true);
        }
        else
        {
            myAnimator.SetBool("isScared", false);
        }
    }
}
