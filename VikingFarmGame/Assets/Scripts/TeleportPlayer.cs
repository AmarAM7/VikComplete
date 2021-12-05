using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPlayer : MonoBehaviour
{
    public Transform teleportTarget;
    public Transform thePlayer;
    //public CharacterController controller;
    //public GameObject Player;
    //public Sail sail;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            //Player.SetActive(false);
            thePlayer.transform.position = teleportTarget.transform.position;
            //thePlayer.transform.position = new Vector3(244, 3, -167);
            //SceneManager.LoadScene("HauntedMine");
            //Player.SetActive(true);
            //controller.enabled = true;
            //GetComponent<Sail>().enabled = true;
        }
    }

    //void changePosition()
    //{

    //}
}
