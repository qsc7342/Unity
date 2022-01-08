using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{
    public GameObject charaterPrefab;
    private GameObject character;
    private AudioSource audioSource;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() {
        Debug.Log("Mouse down appeared");
        CharacterStat characterStat = charaterPrefab.GetComponent<CharacterStat>();
        if(character == null && characterStat.canCreate(gameManager.seed)) {
            Debug.Log("Mouse DOwn.");
            audioSource.PlayOneShot(audioSource.clip);
            character = (GameObject) Instantiate(charaterPrefab, transform.position, Quaternion.identity);
            gameManager.seed -= character.GetComponent<CharacterStat>().cost;
            gameManager.updateText();
        }
    }
}
