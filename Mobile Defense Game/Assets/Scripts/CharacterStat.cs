 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public int level = 1;
    public int hp = 30;
    public int maxHp = 30;
    public int damage = 5;
    public int cost = 130;
    public int upgradeCost = 200;
    public float coolTime = 2.0f;
    // Start is called before the first frame update
    private Animator animator;


    public int attacked(int damage) {
        hp -= damage;
        if(hp <= 0) {
            animator.SetTrigger("Die");
            Destroy(gameObject, 1.5f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        return hp;
    }
    public bool canCreate(int seed) {
        if(cost <= seed) return true;
        return false;
    }
    public bool canLevelUp(int seed) {
        if(seed < upgradeCost) return false;
        if(level < 3) {
            return true;
        }
        else {
            return false;
        }
    }

    public void increaseLevel() {
        if(level == 1) {
            level = 2;
            maxHp += 25;
            hp = maxHp;
            damage += 5;
            transform.localScale += new Vector3(0.01f, 0.01f, 0);
            // SpriteRenderer colors = GetComponent<SpriteRenderer>();
            // colors.color = Color.red;
        }
        else if(level == 2) {
            level = 3;
            maxHp += 50;
            hp = maxHp;
            damage += 5;
            transform.localScale += new Vector3(0.01f, 0.01f, 0); 
            // SpriteRenderer colors = GetComponent<SpriteRenderer>();
            // colors.color = Color.blue;
        }
    }
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
