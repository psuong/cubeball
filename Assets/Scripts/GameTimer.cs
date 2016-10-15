using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {
    public float roundTime = 180f;

    [SerializeField]
    public float timer = 180f;

	// Use this for initialization
	void Start () 
	{
        timer = roundTime;
        StartCoroutine("gameTimer");
	}


    private IEnumerator gameTimer()
    {
        yield return new WaitForSeconds(1f);
        timer -= 1;
    }
	
	// Update is called once per frame
	void Update () {
       
	}
}
