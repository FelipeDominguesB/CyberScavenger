using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{

    public Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.transform.eulerAngles = new Vector3(0, rigidBody.transform.eulerAngles.y + 3, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrou");
    }

}
