using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeAttackInput : MonoBehaviour
{
    private CharacterAnimations playerAnimations;
    public GameObject attackPoint;
    private PlayerShield shield;
    private CharacterSoundFX soundFX;
    void Awake()
    {
        playerAnimations = GetComponent<CharacterAnimations>();
        shield = GetComponent<PlayerShield>();
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimations.Defend(true);
            shield.ActivateShield(true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAnimations.UnfreezeAnimation();
            playerAnimations.Defend(false);
            shield.ActivateShield(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Random.Range(0, 2) > 0)
            {
                playerAnimations.Attack1();
                soundFX.Attack1();
            }
            else
            {
                playerAnimations.Attack2();
                soundFX.Attack1();
            }
        }
    }

    void ActivateAttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void DeactivateAttackPoint()
    {
        if (attackPoint.activeInHierarchy)
            attackPoint.SetActive(false);
    }
}
 