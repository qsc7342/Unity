using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{

    public GameObject image;
    public GameObject character;
    private CharacterStat characterStat;

    public GameObject parent;
    private MonsterStat monsterStat;

    public float max = 100;
    public float current = 100;
    private float scale;
    private int maxHp = 100;
    private int hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        scale = image.transform.localScale.x;
        if(parent.name.Contains("Character")) {
            characterStat = character.GetComponent<CharacterStat>();
        }
        else if(parent.name.Contains("Monster")) {
            monsterStat = character.GetComponent<MonsterStat>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(characterStat != null) {
             maxHp = characterStat.maxHp;
             hp = characterStat.hp;
        }
        else if(monsterStat != null) {
             maxHp = monsterStat.maxHp;
             hp = monsterStat.hp;
        }
        current = (float)hp / (float)maxHp * 100;
        if(current < 0) {
            current = 0;
        }
        Vector2 temp = image.transform.localScale;
        if(monsterStat != null) {
            Debug.Log(current + " " + temp.x);
        }
        temp.x = current/max*scale;
        image.transform.localScale = temp;
    }
}
