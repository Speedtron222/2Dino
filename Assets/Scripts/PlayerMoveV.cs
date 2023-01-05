using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveV : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 1500;
    GroundDetector_Raycast ground;
    public int jumps_max = 2;
    int jumps;
    public AudioSource soundClip;
    public AudioClip otherClip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<GroundDetector_Raycast>();
        soundClip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ground.grounded)
        {
            jumps = jumps_max;
        }
        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            soundClip.clip = otherClip;
            soundClip.volume = 0.1f;
            if (ground.grounded)
            {
                rb.AddForce(new Vector2(0, force));
                soundClip.Play();
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector2(0, force*0.75f));
                soundClip.Play();
            }
            jumps--;
        }
    }
}
