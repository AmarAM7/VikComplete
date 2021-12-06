using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShop : MonoBehaviour
{
    public GameObject panel;
    public GameObject buttonBuy;
    public AudioSource audioo;
    public GameObject triggerExit;
    

    void Start()
    {
        audioo = GetComponent<AudioSource>();
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panel.SetActive(true);
            ButtonAppear();
            
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panel.SetActive(false);
            ButtonDisappear();
            triggerExit.SetActive(true);
        }
    }

    public void ButtonAppear()
    {
        buttonBuy.SetActive(true);
        
    }

    public void ButtonDisappear()
    {
        buttonBuy.SetActive(false);
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioo.Play();
        }
    }

}
