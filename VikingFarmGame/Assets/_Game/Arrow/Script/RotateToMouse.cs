using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public Camera cam;
    
    public float range = 100f;

    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cam != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                RotateToMouseDirection(gameObject, hit.point);

            }
            else
            {
                //var pos = rayMouse.GetPoint(maximumLength);
                RotateToMouseDirection(gameObject, pos);
            }
        }
        else
        {
            Debug.Log("No Camera");
        }
    }

    void RotateToMouseDirection (GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp (obj.transform.rotation, rotation, 1);
    }

    public Quaternion GetRotation ()
    {
        return rotation;
    }
}
