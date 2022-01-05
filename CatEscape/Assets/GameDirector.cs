using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;
    // Start is called before the first frame update
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
    }
    public void DecreaseHp() {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
