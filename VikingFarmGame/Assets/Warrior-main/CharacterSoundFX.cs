using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundFX : MonoBehaviour
{
    private AudioSource soundFX;

    public AudioClip attacksound1, attacksound2, diesound;
    // Start is called before the first frame update
    void Awake()
    {
        soundFX = GetComponent<AudioSource>();
    }

    
    public void Attack1()
    {
        soundFX.clip = attacksound1;
        soundFX.Play();
    }

    public void Attack2()
    {
        soundFX.clip = attacksound2;
        soundFX.Play();
    }

    public void Die()
    {
        soundFX.clip = diesound;
        soundFX.Play();
    }
}
