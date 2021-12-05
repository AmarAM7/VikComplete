using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sail : MonoBehaviour
{
    public GameObject propPlayer;
    public GameObject Player;
    public GameObject Ship;
    public GameObject Fakeship;
    public GameObject cameraBase;
    public GameObject _camera;
    //public PlayerMove movee;
    public CharacterController controller;



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
            Fakeship.SetActive(false);
            Ship.SetActive(true);
            cameraBase.SetActive(true);
            _camera.SetActive(false);
            //GetComponent<MovementInput>().enabled = false;
            controller.enabled = false;

        }
    }

}
