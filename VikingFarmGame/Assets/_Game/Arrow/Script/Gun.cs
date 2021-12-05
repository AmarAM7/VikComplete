using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    //public GameObject bullet;

    public Camera fpsCam;

    private float nextTimeToFire = 0f;

    //public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    //public List<GameObject> vfx = new List<GameObject>();
    //private GameObject effectToSpawn;
    public GameObject firePoint;
    //public RotateToMouse rotateToMouse;
    public AudioSource audiooo;

    // Start is called before the first frame update
    void Start()
    {
        //effectToSpawn = vfx[0];
        audiooo = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift) && Time.time >= nextTimeToFire)
        {
            //nextTimeToFire = Time.time + 1f / effectToSpawn.GetComponent<ProjectileMove> ().fireRate;
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            //SpawnVFX();
            audiooo.Play();
        }

        //GameObject shot = GameObject.Instantiate(projectile, fpsCam.transform.position, fpsCam.transform.rotation);
        //shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
    }

    void Shoot ()
    {
        //muzzleFlash.Play();

        RaycastHit hit;
      if ( Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
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

    /*void SpawnVFX()
    {
        GameObject vfx;

        if(firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if (rotateToMouse != null)
            {
                vfx.transform.localRotation = rotateToMouse.GetRotation();
            }
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }*/
}
