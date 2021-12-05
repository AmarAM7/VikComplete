using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossweapon : MonoBehaviour
{
    public int damagePerTick = 1;
    public float damageTickTime = 1.0f;

    private List<Health> playersInLava = new List<Health>();
    private float damageTickCooldown;
    public Vector3 speed;
    public AudioSource audioClip;

    // Start is called before the first frame update
    public void Start()
    {
        //cameraShake = GetComponent<CameraShake>();
    }

    void Update()
    {
        if (playersInLava.Count > 0)
        {
            if (damageTickCooldown <= 0.0f)
            {
                foreach (Health health in playersInLava)
                {
                    health.AlterHealth(-1 * damagePerTick);
                    audioClip.Play();
                }

                damageTickCooldown = damageTickTime;
            }
            //GetComponent<CameraShake>().enabled = true;
        }
        else
        {
            damageTickCooldown -= Time.deltaTime;
            //GetComponent<CameraShake>().enabled = false;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();

        if (health != null)
            playersInLava.Add(health);

        damageTickCooldown = 0.0f;
    }

    void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{

        //}

        Health health = other.GetComponent<Health>();

        if (health != null)
            playersInLava.Remove(health);

    }

    /*public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = SimpleMove(speed);
        }
            
    }*/
}
