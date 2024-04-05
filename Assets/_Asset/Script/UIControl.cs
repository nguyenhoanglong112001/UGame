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
    // Update is called once per frame
    void Start()
    {
    }
    void Update()
    {
        SetText();
    }

    private void SetText()
    {
        if(Player1.Alive == true && Player2.Alive == false)
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
            Anoun.gameObject.SetActive(false);
        }
    }
}
