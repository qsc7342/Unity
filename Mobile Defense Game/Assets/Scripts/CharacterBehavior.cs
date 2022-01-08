using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    CharacterStat characterStat;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        characterStat = gameObject.GetComponent<CharacterStat>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        if(characterStat.canLevelUp(gameManager.seed)) {
            characterStat.increaseLevel();
            gameManager.seed -= characterStat.upgradeCost;
            gameManager.updateText();
        }   
    }
}
 