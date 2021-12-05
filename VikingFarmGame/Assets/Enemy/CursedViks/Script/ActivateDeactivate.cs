using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivate : MonoBehaviour
{
    public Waypoints _wayPoints;
    public Waypoint _wayPoint;

    // Start is called before the first frame update
    void Start()
    {
        _wayPoint = GetComponent<Waypoint>();
        _wayPoints = GetComponent<Waypoints>();
        _wayPoints.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _wayPoints.enabled = true;
            _wayPoint.enabled = false;
        }
        else
        {
            _wayPoints.enabled = false;
            _wayPoint.enabled = true;
        }
    }
}
