using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : GameManager
{
    private Rigidbody playerRb;

    public float JumpForce = 10.0f;

    public bool isOnGround = true;

    public float gravityModifier;

    public bool gameover = false;

    public ParticleSystem explosiveParticle;

    public ParticleSystem dirtySplatter;

    private Animator playerAnim;

    private AudioSource playerAudio;

    public AudioClip jumpSound;

    public AudioClip crashSound;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameover)
        {
          playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);

          isOnGround = false;

          playerAnim.SetTrigger("Jump_trig");

          dirtySplatter.Stop();

          playerAudio.PlayOneShot(jumpSound, 5.0f);

          playerAnim.enabled = gameover;
          Debug.Log(gameStart + "Is game started");
        }

    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

            dirtySplatter.Play();
        }else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameover = true;

            Debug.Log("GameOver!");

            playerAnim.SetBool("Death_b", true);

            playerAnim.SetInteger("DeathType_int", 1);

            explosiveParticle.Play();

            dirtySplatter.Stop();

            playerAudio.PlayOneShot(crashSound, 1.0f);
        }        
    }
}
