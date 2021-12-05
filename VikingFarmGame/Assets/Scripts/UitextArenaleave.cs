using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UitextArenaleave : MonoBehaviour
{
    public GameObject uiObject;
    //ArenaLeave arenaLeave;

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(true);
        //GetComponent<ArenaLeave>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            //StartCoroutine("WaitForSec");
            //GetComponent<ArenaLeave>().enabled = true;
        }
        
    }
    /*public void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(false);
            //StartCoroutine("WaitForSec");
        }
        
    }*/



    /*IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        //Destroy(uiObject);
    }*/
}
