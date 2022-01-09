using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject respawnSpot1;
    public GameObject respawnSpot2;
    public GameObject respawnSpot3;
    public GameObject respawnSpot4;

    public GameObject monster1Prefab;
    public GameObject monster2Prefab;

    private GameObject monsterPrefab;

    private float lastSpawnTime;
    private int spawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();    
        monsterPrefab = monster1Prefab;
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.round <= gameManager.totalRound) {
            float timeGap = Time.time - lastSpawnTime;
            if(((spawnCount == 0 && timeGap > gameManager.roundReadyTime)
            || timeGap > gameManager.spawnTime)
            && spawnCount < gameManager.spawnNumber) {
                lastSpawnTime = Time.time;
                int respawnSpotNumber = Random.Range(1, 5);
                GameObject respawnSpot = null;
                if(respawnSpotNumber == 1) respawnSpot = respawnSpot1;
                if(respawnSpotNumber == 2) respawnSpot = respawnSpot2;
                if(respawnSpotNumber == 3) respawnSpot = respawnSpot3;
                if(respawnSpotNumber == 4) respawnSpot = respawnSpot4;

                Instantiate(monsterPrefab, respawnSpot.transform.position, Quaternion.identity);
                spawnCount++;
            }
        }

        if(spawnCount == gameManager.spawnNumber
        && GameObject.FindGameObjectWithTag("Monster") == null) {
            gameManager.clearRound();
            spawnCount = 0;
            lastSpawnTime = Time.time;

            if(gameManager.round == 2) {
                monsterPrefab = monster2Prefab;
                gameManager.spawnTime = 2.0f;
                gameManager.spawnNumber = 10;
            }
        } 
    }
}
