using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator anime;
    // Start is called before the first frame update
    void Awake()
    {
        anime = GetComponent<Animator>();
    }

    public void Walk(bool walk)
    {
        anime.SetBool("Walk", walk);
    }

    /*public void Right(bool right)
    {
        anime.SetBool("Right", right);
    }

    public void Left(bool left)
    {
        anime.SetBool("Left", left);
    }*/

    public void Defend(bool defend)
    {
        anime.SetBool("Defend", defend);
    }

    public void Attack1()
    {
        anime.SetTrigger("Attack1");
    }

    public void Attack2()
    {
        anime.SetTrigger("Attack2");
    }

    public void Dead()
    {
        anime.SetTrigger("Dead");
    }

    void FreezeAnimation()
    {
        anime.speed = 0f;
    }

    public void UnfreezeAnimation()
    {
        anime.speed = 1f;
    }
}
