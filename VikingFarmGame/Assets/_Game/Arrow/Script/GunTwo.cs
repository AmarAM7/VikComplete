using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTwo : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    //public GameObject bullet;

    public Camera Cam;

    private float nextTimeToFire = 0f;

    //public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            
        }

        //GameObject shot = GameObject.Instantiate(projectile, fpsCam.transform.position, fpsCam.transform.rotation);
        //shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
    }

    void Shoot()
    {
        //muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
