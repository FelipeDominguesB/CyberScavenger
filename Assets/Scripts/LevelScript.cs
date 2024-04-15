using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    PlayerScript playerScript;
    public int nextLevelIndex;
    public GameObject gameOverScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerScript.IsAlive())
            gameOverScreen.SetActive(true);
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void FinishLevel()
    {   
        SceneManager.LoadScene(nextLevelIndex);
    }


}
