using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spine : MonoBehaviour
{
    public Transform spine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        spine.rotation = Quaternion.LookRotation(Camera.main.transform.forward, spine.up);
        spine.transform.Rotate(30, 0, 0);
    }
}
