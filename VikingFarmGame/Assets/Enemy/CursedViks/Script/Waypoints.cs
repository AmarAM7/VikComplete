using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waypoints : MonoBehaviour
{
    public GameObject player;
    public float distance;
    public bool isAngered;

    public NavMeshAgent _agent;
    private Animator anim;
    private Waypoint wayPoint;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        wayPoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (distance <= 5)
        {
            isAngered = true;
            anim.SetBool("isRunning", true);
            
        }
        if (distance > 5f)
        {
            isAngered = false;
            anim.SetBool("isRunning", false);
            
        }

        if (isAngered)
        {
            _agent.isStopped = false;
            _agent.SetDestination(player.transform.position);
            wayPoint.enabled = false;
        }
        if (!isAngered)
        {
            _agent.isStopped = true;
            wayPoint.enabled = true;
        }
    }

}
