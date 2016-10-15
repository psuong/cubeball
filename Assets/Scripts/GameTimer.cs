using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {
    public float roundTime = 180f;
    [SerializeField]
    private float timer = 180f;
    public float Timer {get  { return timer; } }
    private bool isRunning = true;

    void OnEnable()
    {
        DetermineWinner.TimeUpEvent += ResetTimer;
    }

	// Use this for initialization
	void Start () {
        timer = roundTime;
        StartCoroutine("gameTimer");
	}

    private IEnumerator gameTimer()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1;
        }
       
    }

    public void PauseTimer()
    {
        StopCoroutine("gameTimer");
        isRunning = false;
    }

    public void ResumeTimer()
    {
        isRunning = true;
        StartCoroutine("gameTimer");
    }

    private void ResetTimer()
    {
        StopCoroutine("gameTimer");
        isRunning = false;
        timer = roundTime;
    }
	

}
