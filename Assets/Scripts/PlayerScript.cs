using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering.Universal;
using UnityEngine.TextCore.Text;

public class PlayerScript : MonoBehaviour, IPlayer
{


    //teste

    private Animator _animator;

    // animation IDs
    private int _animIDSpeed;
    private int _animIDGrounded;
    private int _animIDJump;
    private int _animIDFreeFall;
    private int _animIDMotionSpeed;

    //teste


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
    private void AssignAnimationIDs()
    {
        _animIDSpeed = Animator.StringToHash("Speed");
        _animIDGrounded = Animator.StringToHash("Grounded");
        _animIDJump = Animator.StringToHash("Jump");
        _animIDFreeFall = Animator.StringToHash("FreeFall");
        _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
    }


    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out _animator);
        currentHealth = maxHealth;
        AssignAnimationIDs();
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
        isOffGround = !Physics.Raycast(transform.position, Vector3.down, 0.2F);

        if(!isOffGround)
        {
            _animator.SetBool(_animIDGrounded, true);
            _animator.SetBool(_animIDFreeFall, false);
            _animator.SetBool(_animIDFreeFall, false);
            _animator.SetBool(_animIDJump, false);
        }
        else
        {
            _animator.SetBool(_animIDJump, false);
            _animator.SetBool(_animIDGrounded, false);
            _animator.SetBool(_animIDFreeFall, true);
        }

    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (Vector3.left * moveSpeed * Time.fixedDeltaTime);
            character.transform.eulerAngles = new Vector3(0, 270, 0);

        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (Vector3.right * moveSpeed * Time.fixedDeltaTime);
            character.transform.eulerAngles = new Vector3(0, 90, 0);

        }
        else
        {
        }


        if (Input.GetKeyDown(KeyCode.E))
            this.ApplyDamage(1);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _animator.SetBool(_animIDFreeFall, false);
            _animator.SetBool(_animIDGrounded, true);

        }

        if (Input.GetKeyDown(KeyCode.Space) && !isOffGround)
        {
            _animator.SetBool(_animIDJump, true);

            character.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOffGround = true;

        }


        //else if(isOffGround)
        //{
        //    _animator.SetBool(_animIDFreeFall, true);

        //}
        //else
        //{
        //    _animator.SetBool(_animIDGrounded, true);

        //}

        _animator.SetFloat(_animIDMotionSpeed, 1);


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

    private void OnFootstep(AnimationEvent animationEvent)
    {
        this.PlayWalkingSound();

    }

    private void OnLand(AnimationEvent animationEvent)
    {
        Debug.Log("Landed");
        this.isOffGround = false;
        _animator.SetBool(_animIDFreeFall, false);
        _animator.SetBool(_animIDGrounded, true);

        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            this.AudioSource.clip = LandingAudioClip;
            this.AudioSource.Play();
        }
    }
}
