using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaLeave : MonoBehaviour
{
    public GameObject Player;
    public GameObject propPlayer;
    public GameObject Ship;
    public GameObject ArenaFakeship;
    public GameObject cameraBase;
    public GameObject _camera;
    //public PlayerMove movee;
    public CharacterController controller;
    public CharacterController shipController;
    public Transform teleportTarget;
    public Transform theShip;


    // Start is called before the first frame update
    void Start()
    {
        //movee = GetComponent<PlayerMove>();
        GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.SetActive(false);
            propPlayer.SetActive(true);
            ArenaFakeship.SetActive(false);
            Ship.SetActive(true);
            cameraBase.SetActive(true);
            _camera.SetActive(false);
            //GetComponent<PlayerMove>().enabled = false;
            controller.enabled = false;
            theShip.transform.position = teleportTarget.transform.position;
            shipController.enabled = true;
        }
    }
}
