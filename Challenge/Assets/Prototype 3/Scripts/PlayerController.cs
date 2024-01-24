using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Prototype_3.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private Animator playerAnimation;
        private Rigidbody rigidBody;
        private AudioSource audioSource;

        [SerializeField] private ParticleSystem explosionParticle;
        [SerializeField] private ParticleSystem dirtParticle;
        [SerializeField] private AudioClip crashSound;
        [SerializeField] private AudioClip jumpSound;
        [SerializeField] private float jumpForce;
        [SerializeField] private float gravityModifier;
        [SerializeField] private bool isOnGround = true;

        public bool gameOver = false;
        
        private void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            playerAnimation = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();

            Physics.gravity *= gravityModifier;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
            {
                rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnimation.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                audioSource.PlayOneShot(jumpSound, 1.0f);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
                dirtParticle.Play();
            }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
                Debug.Log("Game Over");

                playerAnimation.SetBool("Death_b", true);
                playerAnimation.SetInteger("DeathType_int", 1);
                explosionParticle.Play();
                dirtParticle.Stop();
                audioSource.PlayOneShot(crashSound, 1.0f);
            }
        }
    }
}
