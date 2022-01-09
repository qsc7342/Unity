using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.Advertisements;

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
		Screen.SetResolution(1920, 1200, true);
        // Advertisement.Initialize("4551909", false);
        // ShowRewardedAd();
	}
	
    // private void ShowRewardedAd() {
    //     if(Advertisement.IsReady("rewardedVideo"));
    //     {
    //         var options = new ShowOptions { resultCallback = HandleShowResult };
    //         Advertisement.Show("rewardedVideo", options);
    //     }
    // }
    // private void HandleShowResult(ShowResult result) {
    //     switch(result) {
    //         case ShowResult.Finished:
    //             Debug.Log("광고 성공");
    //             break;
    //         case ShowResult.Skipped:
    //             Debug.Log("스킵");
    //             break;
    //         case ShowResult.Failed:
    //             Debug.Log("실패");
    //             break;
    //     }
    // }
	void Update () {
		
	}
}
