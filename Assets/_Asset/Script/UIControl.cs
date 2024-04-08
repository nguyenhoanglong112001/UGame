using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] private Text message;
    [SerializeField] private Canvas Anoun;
    [SerializeField]private JuggController Player1;
    [SerializeField]private DrogonController Player2;
    [SerializeField] private Text time;
    [SerializeField] private float battletime;
    [SerializeField] private Text leftscore;
    [SerializeField] private Text rightscore;
    private int player1score;
    private int player2score;
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
        player1score = 0;
        player2score = 0;
        leftscore.text = player1score.ToString();
        rightscore.text = player2score.ToString();
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
        if (Player1.Alive == true && Player2.Alive == false)
        {
            Anoun.gameObject.SetActive(true);
            message.text = "Player1 winning";
        }
        else if (Player1.Alive == false && Player2.Alive == true)
        {
            Debug.Log("Player win");
            Anoun.gameObject.SetActive(true);
            message.text = "Player2 winning";
        }
        else if (Player1.Alive == true && Player2.Alive == true)
        {
            if(remainingtime <= 0)
            {
                if (Player1.currentHP > Player2.currentHP)
                {
                    Anoun.gameObject.SetActive(true);
                    message.text = "Player1 winning";
                }
                else if (Player1.currentHP < Player2.currentHP)
                {
                    Anoun.gameObject.SetActive(true);
                    message.text = "Player2 winning";
                }
                else if (Player1.currentHP == Player2.currentHP)
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
