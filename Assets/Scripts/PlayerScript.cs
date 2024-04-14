using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.TextCore.Text;

public class PlayerScript : MonoBehaviour, IPlayer
{

    public Rigidbody character;
    public Collider CharacterCollider;
    public AudioSource AudioSource;
    public List<AudioClip> AudioClipList;
    public AudioClip JumpAudioClip;
    public AudioClip LandingAudioClip;

    public float moveSpeed = 0.1F;
    public int maxHealth = 1;
    public int jumpForce = 70;

    private int currentHealth;
    private bool isOffGround = false;

    private float secondsWalking = 0;
    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public bool IsAlive()
    {
        return GetCurrentHealth() > 0;
    }

   

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    
    // Update is called once per frame
    void Update()
    {
        if(IsAlive())
        {
            CheckGroundDistance();
            Move();
        }

    }

    private void CheckGroundDistance()
    {
        isOffGround = !Physics.Raycast(transform.position, Vector3.down, 0.1F);

    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (Vector3.left * moveSpeed);
            character.transform.eulerAngles = new Vector3(0, 270, 0);

            this.secondsWalking += Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (Vector3.right * moveSpeed);
            character.transform.eulerAngles = new Vector3(0, 90, 0);

            this.secondsWalking += Time.deltaTime;
        }
        else
        {
            this.secondsWalking = 0;
        }


        if (secondsWalking != 0 && secondsWalking > 0.4F && !isOffGround)
        {
            this.PlayWalkingSound();
            secondsWalking = 0;
        }

        if (Input.GetKeyDown(KeyCode.E))
            this.ApplyDamage(1);

        if (Input.GetKeyDown(KeyCode.Space) && !isOffGround)
        {
            character.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOffGround = true;
        }

     
    }

    [ContextMenu("PlaySound")]
    public void PlayWalkingSound()
    {

        int random = Random.Range(0, 5);
        Debug.Log(random);

        AudioClip audioClip = AudioClipList.ElementAt(random);
        AudioSource.clip = audioClip;
        this.AudioSource.Play();
    }


    private void PlayJumpingSound()
    {
        this.AudioSource.clip = LandingAudioClip;
        this.AudioSource.Play();
    }


    public void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Floor" && isOffGround)
        {
            this.AudioSource.clip = LandingAudioClip;
            this.AudioSource.Play();
            secondsWalking = 0;
        }
    }
}
