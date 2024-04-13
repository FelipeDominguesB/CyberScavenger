using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{


    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.FollowPlayer();
    }


    private void FollowPlayer()
    {
        this.transform.position = new Vector3(player.transform.position.x, 0.8F, -10);
    }
}
