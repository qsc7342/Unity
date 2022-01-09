using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text seedText;
    public Text roundText;
    public Text roundStartText;

    private AudioSource audioSource;
    public int round = 0;
    public int seed = 1000;
    public int roundReadyTime = 5;
    public int totalRound = 3;
    public int reward = 500;
    public float spawnTime = 2.5f;
    public int spawnNumber = 5;

    public void clearRound() {
        if(round < totalRound) {
            nextRound();
            seed += reward;
            updateText();
            spawnTime -= 0.2f;
            spawnNumber += 3;
            reward += 150;
        }
    }
    public void nextRound() {
        round = round + 1;
        Debug.Log("round : " + round);
        if(round == 1) {
            roundText.text = "ROUND 0" + round;
            roundStartText.text = "ROUND 0" + round;
        }
        else if(round < 10) {
            roundText.text = "ROUND 0" + round;
            roundStartText.text = "ROUND 0" + round;
            roundStartText.GetComponent<Animator>().SetTrigger("Round Start");
        }
        else {
            roundText.text = "ROUND " + round;
            roundStartText.text = "ROUND " + round;
            roundStartText.GetComponent<Animator>().SetTrigger("Round Start");
        }
        audioSource.PlayOneShot(audioSource.clip);
    }
    public void updateText() {
        seedText.text = "씨앗: " + seed;
    }
    // Start is called before the first frame update
    void Start()
    {   
        seed = 5000;
        audioSource = roundStartText.GetComponent<AudioSource>();
        updateText();
        nextRound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
