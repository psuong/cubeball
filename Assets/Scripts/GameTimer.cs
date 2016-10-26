using UnityEngine;
using System.Collections;

/// <summary>
/// Countdown timer
/// </summary>
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

	/// <summary>
	/// Runs timer down by one second
	/// </summary>
	/// <returns>The timer.</returns>
    private IEnumerator gameTimer()
    {
        if (timerIsRunning)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1;
        }
    }

	/// <summary>
	/// Pauses Timer by stoppng the gameTimer coroutine
	/// </summary>
    public void PauseTimer()
    {
        timerIsRunning = false;
        StopCoroutine("gameTimer");
    }

	/// <summary>
	/// Resumes the timer. By restarting the coroutine
	/// </summary>
    public void ResumeTimer()
    {
        timerIsRunning = true;
        StartCoroutine("gameTimer");
    }

	/// <summary>
	/// Resets the timer to the roundtime and restarts coroutine
	/// </summary>
    public void RestartTimer()
    {
        timer = roundTime;
        timerIsRunning = true;
        StartCoroutine("gameTimer");
    }
  
}
