using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth;
    public Text currentHealthLabel;
    //public Image deadScreen;

    private int currentHealth;
    private bool isDead;

    private Animator myAnimator;

    public void Start()
    {
        myAnimator = GetComponent<Animator>();
        currentHealth = maxHealth;
        //isDead = false;
        UpdateGUI();
    }

    void UpdateGUI()
    {
        currentHealthLabel.text = currentHealth.ToString();
        //deadScreen.gameObject.SetActive(isDead);
    }

    public void AlterHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        CheckDeadd();
        UpdateGUI();
    }

    private void CheckDeadd()
    {
        if (isDead)
            return;

        if (currentHealth == 0)
        {
            isDead = true;
            GetComponent<BossBehaviour>().enabled = false;
            myAnimator.SetBool("isDead", true);
            Destroy(gameObject, 5);
        }
        else
        {
            myAnimator.SetBool("isDead", false);
        }
    }
}
