using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageArrive : MonoBehaviour
{
    public GameObject propPlayer;
    public GameObject Player;
    public GameObject Ship;
    public GameObject Fakeship;
    public GameObject cameraBase;
    public GameObject _camera;
    public Transform teleportTarget;
    public Transform thePlayer;
    public CharacterController controller;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Player.SetActive(true);
            propPlayer.SetActive(false);
            Fakeship.SetActive(true);
            Ship.SetActive(false);
            cameraBase.SetActive(false);
            _camera.SetActive(true);
            thePlayer.transform.position = teleportTarget.transform.position;
            controller.enabled = true;
        }
    }
}
