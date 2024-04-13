using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.TextCore.Text;

public class PlayerScript : MonoBehaviour, IPlayer
{
    public Rigidbody character;
    public Collider CharacterCollider;

    public float moveSpeed = 0.1F;
    public int maxHealth = 1;
    public int jumpForce = 70;

    private int currentHealth;
    private bool isOffGround = false;
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

    public void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (Vector3.left * moveSpeed);
            character.transform.eulerAngles = new Vector3(0, 270, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (Vector3.right * moveSpeed);
            character.transform.eulerAngles = new Vector3(0, 90, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space) && !isOffGround)
        {
            character.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOffGround = true;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }


    private void CheckGroundDistance()
    {
        isOffGround = !Physics.Raycast(transform.position, Vector3.down, 0.1F);
    }
    // Update is called once per frame
    void Update()
    {
        CheckGroundDistance();
        Move();

    }
}
