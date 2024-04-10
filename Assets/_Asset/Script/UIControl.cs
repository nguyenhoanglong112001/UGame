using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] private Text message;
    [SerializeField] private Canvas Anoun;
    [SerializeField]private HealthManager[] characterhealth;
    [SerializeField] private Text time;
    [SerializeField] private float battletime;
    private bool isgameend;
    private float remainingtime;
    private bool Istimerunning;
    // Update is called once per frame
    void Start()
    {
        Istimerunning = true;
        remainingtime = battletime;
        time.text = remainingtime.ToString();
        Anoun.gameObject.SetActive(false);
        isgameend = false;
        SetText();
    }
    void Update()
    {
        SetText();
        BattleTime();
    }

    private void SetText()
    {
        isgameend = true;
        if (characterhealth[0].Alive == true && characterhealth[1].Alive == false)
        {
            Anoun.gameObject.SetActive(true);
            message.text = "Player1 winning";
        }
        if (characterhealth[0].Alive == false && characterhealth[1].Alive == true)
        {
            Debug.Log("Player win");
            Anoun.gameObject.SetActive(true);
            message.text = "Player2 winning";
        }
        if (characterhealth[0].Alive == true && characterhealth[1].Alive == false)
        {
            if(remainingtime <= 0)
            {
                if (characterhealth[0].currentHP > characterhealth[1].currentHP)
                {
                    Anoun.gameObject.SetActive(true);
                    message.text = "Player1 winning";
                }
                else if (characterhealth[0].currentHP < characterhealth[1].currentHP)
                {
                    Anoun.gameObject.SetActive(true);
                    message.text = "Player2 winning";
                }
                else if (characterhealth[0].currentHP == characterhealth[1].currentHP)
                {
                    message.text = "Draw";
                }
            }
        }
    }

    public void BattleTime()
    {
        if(Istimerunning)
        {
            if (remainingtime > 0)
            {
                remainingtime -= Time.deltaTime;
            }
            else
            {
                remainingtime = 0;
                Istimerunning = false;
            }
        }
        float minute = Mathf.FloorToInt(remainingtime / 60);
        float second = Mathf.FloorToInt(remainingtime % 60);
        time.text = string.Format("{0:00}:{1:00}", minute, second);
    }
}
