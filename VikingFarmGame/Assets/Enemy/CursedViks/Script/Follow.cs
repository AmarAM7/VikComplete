using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    RaycastHit InteractionInfo;
    public Transform Pressureplates;
    //public GameObject pPlate;
    public int MoveSpeed = 4;
    //public int MaxDist = 10;
    public int MinDist = 2;
    //public ActivateStairs activateStairs; 
    public bool OnCommand;

    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.FindGameObjectsWithTag("LittleNightmare1");
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        myAnimator.SetBool("isScared", false);
        // && InteractionInfo.transform.gameObject.tag != "LittleNightmare1"
     
        if (OnCommand)
        {
            transform.LookAt(Pressureplates);

            if (Vector3.Distance(transform.position, Pressureplates.position) >= MinDist)
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                
                myAnimator.SetBool("isRunning", true);
            }
            else
            {                
                myAnimator.SetBool("isRunning", false);
                transform.position = Vector3.zero;
                //aiBehaviour.enabled = true;
            }
        }
    }
}
