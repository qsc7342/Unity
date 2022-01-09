using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    // public float speed = 1.0f;
    private MonsterStat monsterStat;
    private Animator animator;
    private bool attacking = false;
    private float lastAttackTime;
    private CharacterStat targetStat;
    public bool died = false;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        animator = gameObject.GetComponent<Animator>();
        monsterStat = gameObject.GetComponent<MonsterStat>();   
    }

    // Update is called once per frame
    void Update()
    {   
        if(died) {
            attacking = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else {
            transform.Translate(Vector2.left * monsterStat.speed * Time.deltaTime);
            if(attacking) {
                transform.Translate(Vector2.right * monsterStat.speed * Time.deltaTime);
            }

            if(targetStat != null && targetStat.hp <= 0) {
                targetStat = null;
                attacking = false;
                animator.SetTrigger("Walk");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.name == "Fence") {
           Destroy(gameObject);
       } 
       else if(other.gameObject.tag == "Character") {
           Debug.Log("공격");
           attacking = true;
           lastAttackTime = Time.time;
           animator.SetTrigger("Attack");
           targetStat = other.gameObject.GetComponent<CharacterStat>();
       }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Character") {
            if(Time.time - lastAttackTime > monsterStat.coolTIme) {
                lastAttackTime = Time.time;
                int hp = other.gameObject.GetComponent<CharacterStat>().attacked(monsterStat.damage);
                if(hp <= 0) {
                    attacking = false;
                    animator.SetTrigger("Walk");
                }
            }
        }
    }
}
