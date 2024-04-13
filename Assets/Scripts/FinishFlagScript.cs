using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFlagScript : MonoBehaviour
{
    public Rigidbody rigidBody;
    private LevelScript levelScript;

    // Start is called before the first frame update
    void Start()
    {
        levelScript = FindAnyObjectByType<LevelScript>().GetComponent<LevelScript>();


    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.transform.eulerAngles = new Vector3(0, rigidBody.transform.eulerAngles.y + 3, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        levelScript.FinishLevel();
    }
}
