using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        float yMovement = 0;

        int rotationAngle = 0;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            xMovement -= moveSpeed;
            rotationAngle += 180;

            character.transform.position = new Vector3(character.transform.position.x + xMovement, character.transform.position.y + yMovement);
            character.transform.eulerAngles = new Vector3(character.transform.rotation.x, character.transform.rotation.y, rotationAngle);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            xMovement += moveSpeed;
            rotationAngle = 0;
            character.transform.position = new Vector3(character.transform.position.x + xMovement, character.transform.position.y + yMovement);
            character.transform.eulerAngles = new Vector3(character.transform.rotation.x, character.transform.rotation.y, rotationAngle);
        }



        if (Input.GetKeyDown(KeyCode.Q))
            this.ApplyDamage(1);
    }
}
