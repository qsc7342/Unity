using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    CharacterStat characterStat;
    private GameManager gameManager;

    public GameObject bullet;
    private Animator animator;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        characterStat = gameObject.GetComponent<CharacterStat>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void attack(int damage) {
        animator.SetTrigger("Attack");
        audioSource.PlayOneShot(audioSource.clip);
        GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        currentBullet.GetComponent<BulletBehavior>().setDamage(damage);
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
 