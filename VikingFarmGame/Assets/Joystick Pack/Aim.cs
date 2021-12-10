using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Bow();
        NoAim();
    }

    public void Bow()
    {
        myAnimator.SetBool("isBowingAim", true);
    }

    
    public void NoAim()
    {
        myAnimator.SetBool("isBowingAim", false);
        
    }
}
