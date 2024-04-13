using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{

    public int nextLevelIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void RestartLevel()
    {
        SceneManager.LoadScene(this.gameObject.scene.buildIndex);
    }

    public void FinishLevel()
    {   
        SceneManager.LoadScene(nextLevelIndex);
    }


}
