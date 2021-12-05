using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemDestroy : MonoBehaviour
{
    public float damage = 10f;
    public float range = 3f;
    public float fireRate = 15f;


    public Camera fpsCam;
    //public GameObject crossHair;

    private float nextTimeToFire = 0f;

    
    public GameObject impactEffect;
    
    //public GameObject firePoint;
    
    public AudioSource audiooo;

    // Start is called before the first frame update
    void Start()
    {
        audiooo = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            
            audiooo.Play();
        }
    }

    void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            DestroyedGem destroyedGem = hit.transform.GetComponent<DestroyedGem>();
            if (destroyedGem != null)
            {
                destroyedGem.TakeDamage(damage);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
