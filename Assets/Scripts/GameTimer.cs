using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public float roundTime = 180f;

    [SerializeField]
    private float timer = 180f;
    public float Timer { get { return timer; } }
    private bool timerIsRunning = true;

    // Use this for initialization
    void Start()
    {

        timer = roundTime;
        StartCoroutine("gameTimer");


    }


    private IEnumerator gameTimer()
    {
        if (timerIsRunning)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1;
        }
    }

    public void PauseTimer()
    {
        timerIsRunning = false;
        StopCoroutine("gameTimer");
    }

    public void ResumeTimer()
    {
        timerIsRunning = true;
        StartCoroutine("gameTimer");
    }

    public void RestartTimer()
    {
        timer = roundTime;
        timerIsRunning = true;
        StartCoroutine("gameTimer");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
