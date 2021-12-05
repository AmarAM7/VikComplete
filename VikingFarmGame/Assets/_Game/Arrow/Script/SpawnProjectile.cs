using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public RotateMouse rotateMouse;

    private GameObject effectToSpawn;
    private float timeToFire = 0;



    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1f / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            
            SpawnnVFX();
            
        }
    }

    void SpawnnVFX()
    {
        GameObject vfx;

        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if (rotateMouse != null)
            {
                vfx.transform.localRotation = rotateMouse.GetRotation();
            }
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}
