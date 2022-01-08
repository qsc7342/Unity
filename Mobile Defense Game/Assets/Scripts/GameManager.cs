using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text seedText;
    public int seed;
    
    public void updateText() {
        seedText.text = "씨앗: " + seed;
    }
    // Start is called before the first frame update
    void Start()
    {   
        seed = 5000;
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
