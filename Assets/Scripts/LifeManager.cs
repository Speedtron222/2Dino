using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int lifes_current;
    public int lifes_max;
    public float invincible_time;
    bool invincible;
    Rigidbody2D rb;
    Animator anim;
    public enum DeathMode { Tp,Reload,Destroy }
    public DeathMode death_mode;
    public Transform respawn;
    public AudioClip otherClip;
    public AudioSource dmgSound;
    // Start is called before the first frame update
    void Start()
    {
        lifes_current = lifes_max;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dmgSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage, bool ignoreInvincible = false)
    {
        if(!invincible || ignoreInvincible)
        {
            lifes_current -= damage;
            dmgSound.clip = otherClip;
            dmgSound.volume = 1.0f;
            dmgSound.Play();
            anim.SetBool("Damaged", true);
            StartCoroutine(Invincible_Coroutine());
            if(lifes_current <= 0)
            {
                Death();
            }
        }
    }

    IEnumerator Invincible_Coroutine()
    {
        invincible = true;
        yield return new WaitForSeconds(invincible_time);
        anim.SetBool("Damaged", false);
        invincible = false;
    }

    public void Death()
    {
        switch (death_mode)
        {
            case DeathMode.Tp:
                rb.velocity = new Vector2(0, 0);
                transform.position = respawn.position;
                lifes_current = lifes_max;
                break;
            case DeathMode.Reload:
                break;
            case DeathMode.Destroy:
                Destroy(gameObject);
                break;
            default:
                break;
        }

    }
}
