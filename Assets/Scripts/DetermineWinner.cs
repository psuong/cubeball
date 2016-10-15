using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetermineWinner : MonoBehaviour {
    private float gameTimer;

    public Score BlueTeam;
    public Score RedTeam;
    public Text winnerText;

    public delegate void TimeUpHandler();
    public static event TimeUpHandler TimeUpEvent;

    void OnEnable()
    {
        TimeUpEvent += GetWinner;
    }
   
    // Use this for initialization
    void Start () {
        gameTimer = GetComponent<GameTimer>().Timer;
	}


    public static void InvokeTimesUp()
    {
        if (TimeUpEvent != null)
        {
            TimeUpEvent();
        }
    }

    private void GetWinner()
    {
        if(BlueTeam.GetScore == RedTeam.GetScore)
        {
            winnerText.text = "TIE";
        }
        else if (BlueTeam.GetScore > RedTeam.GetScore)
        {
            winnerText.text = "Blue Team Wins";
        }
        else
            winnerText.text = "Red Team Wins";
    }

    // Update is called once per frame
    void Update () {
        if (gameTimer == 0f)
        {
            InvokeTimesUp();
        }
    }
}
