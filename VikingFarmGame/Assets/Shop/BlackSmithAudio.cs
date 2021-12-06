using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackSmithAudio : MonoBehaviour
{
	public GameObject triggerExit;
	public AudioSource audiooo;

	void Start()
	{
		audiooo = GetComponent<AudioSource>();
	}

    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Player")
		{
			audiooo.Play();
		}
    }

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			triggerExit.SetActive(false);
		}
	}
}
