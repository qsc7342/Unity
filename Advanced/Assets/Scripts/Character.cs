using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    private string characterName;

    public string GetCharacterName()
    {
        return characterName;
    }

    public void SetCharacterName(string characterName)
    {
        this.characterName = characterName;
    }

    void Start()
    {
        Character character = new Character();
        Debug.Log("캐릭터 생성");
        character.SetCharacterName("당근 캐릭터");
        Debug.Log(character.GetCharacterName());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
