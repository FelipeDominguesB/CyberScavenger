using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.TextCore.Text;

public class PlayerScript : MonoBehaviour, IPlayer
{
    public Rigidbody character;
    public float moveSpeed = 0.1F;
    public void ApplyDamage(int damage)
    {
        throw new System.NotImplementedException();
    }

    public int GetCurrentHealth()
    {
        throw new System.NotImplementedException();
    }

    public int GetMaxHealth()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = 0;
        float rotationAngle = 0;
        bool keyPressed = false;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            xMovement -= moveSpeed;
            rotationAngle += 270;
            keyPressed = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            xMovement += moveSpeed;
            rotationAngle = 90;
            keyPressed = true;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            keyPressed = true;
        }

        character.transform.position = new Vector3(character.position.x + xMovement, character.position.y);
        
        if (keyPressed)
            character.transform.eulerAngles = new Vector3(0, rotationAngle, 0);
        else
            character.transform.eulerAngles = new Vector3(0, character.transform.eulerAngles.y, 0);

        if (Input.GetKeyDown(KeyCode.Q))
            this.ApplyDamage(1);
    }
}
