using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private HealthScripts healthscript;
    // Start is called before the first frame update
    void Awake()
    {
       healthscript = GetComponent<HealthScripts>();
    }
    public void ActivateShield(bool shieldactive)
    {
        healthscript.ShieldActivated = shieldactive;
    }
}
