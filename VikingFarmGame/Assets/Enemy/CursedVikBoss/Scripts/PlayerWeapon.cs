using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public int damagePerTick = 1;
    public float damageTickTime = 1.0f;

    private List<BossHealth> playersInLava = new List<BossHealth>();
    private float damageTickCooldown;


    // Start is called before the first frame update
    public void Start()
    {

    }

    void Update()
    {
        if (playersInLava.Count > 0)
        {
            if (damageTickCooldown <= 0.0f)
            {
                foreach (BossHealth health in playersInLava)
                {
                    Debug.Log("damage");
                    health.AlterHealth(-1 * damagePerTick);
                }

                damageTickCooldown = damageTickTime;
            }
        }
        else
        {
            damageTickCooldown -= Time.deltaTime;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        BossHealth bossHealth = other.GetComponent<BossHealth>();

        if (bossHealth != null)
        {
            Debug.Log("hitting");
            playersInLava.Add(bossHealth);
        }
            

        damageTickCooldown = 0.0f;
    }

    void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{

        //}

        BossHealth bossHealth = other.GetComponent<BossHealth>();

        if (bossHealth != null)
            playersInLava.Remove(bossHealth);

    }
}

