using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {
    [SerializeField]
    public float timer = 0f;
    public float roundTime = 180f;

    public delegate void TimeUpHandler();
    public static event TimeUpHandler TimeUpEvent;


	// Use this for initialization
	void Start () {
        StartCoroutine("gameTimer");
	}

    public static void InvokeTimesUp()
    {
        if(TimeUpEvent != null)
        {
            TimeUpEvent();
        }
    }

    private IEnumerator gameTimer()
    {
        yield return new WaitForSeconds(1f);
        timer += 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (timer == roundTime)
        {
            InvokeTimesUp();
        }
	
	}
}
