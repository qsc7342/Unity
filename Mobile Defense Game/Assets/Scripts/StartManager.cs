using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

    public void gameStart()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void gameExit()
    {
        Application.Quit();
    }
    
	void Start () {
		
	}
	
	void Update () {
		
	}
}
