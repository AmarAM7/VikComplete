using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthScripts : MonoBehaviour
{
    private CharacterAnimations playerAnimations;

    public float health = 100f;

    //private float xDeath = -90f;
    //private float deathSmooth = 0.9f;
    //private float rotateTime = 0.23f;
    private bool playerdied;
    public bool isPlayer;

    [SerializeField]
    Image healthUI;

    [HideInInspector]
    public bool ShieldActivated;

    private CharacterSoundFX soundFX;

    public void ApplyDamage(float damage)
    {
        if(ShieldActivated)
        {
            return;
        }
       
        health -= damage;

        if(healthUI != null)
        {
            healthUI.fillAmount = health / 100f;
        }
        
        if(health <= 0)
        {
            playerAnimations.Dead();
            soundFX.Die();
            //StartCoroutine(AllowRotate());
            GetComponent<Animator>().enabled = false;
           if(isPlayer)
           {
               GetComponent<PlayeAttackInput>().enabled = false;
               GetComponent<PlayerMove>().enabled = false;
               //Camera.main.transform.SetParent(null);
               GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyCOntroller>().enabled = false;
               
           }
           else
           {
               GetComponent<EnemyCOntroller>().enabled = false;
               GetComponent<NavMeshAgent>().enabled = false;
           }
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        soundFX = GetComponentInChildren<CharacterSoundFX>();
        playerAnimations = GetComponent<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(playerdied)
        {
            //RotateAfterDeath();
            
        }*/
    }

    /*void RotateAfterDeath()
    {
       transform.eulerAngles = new Vector3(
        Mathf.Lerp(transform.eulerAngles.x, xDeath, Time.deltaTime * deathSmooth), 
        transform.eulerAngles.y, transform.eulerAngles.z);

    }*/

    /*IEnumerator AllowRotate()
    {
        playerdied = true;
        yield return new WaitForSeconds(rotateTime);
        playerdied = false;
    }*/
}
