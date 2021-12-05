using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedGem : MonoBehaviour
{
    public float health = 50f;
    public GameObject gems;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        gems.SetActive(true);
    }
}
