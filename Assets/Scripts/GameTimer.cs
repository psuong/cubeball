using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {
    [SerializeField]
    private float timer = 0f;

	// Use this for initialization
	void Start () {
        StartCoroutine("gameTimer");
	}

    private IEnumerator gameTimer()
    {
        yield return new WaitForSeconds(1f);
        timer += 1;
    }
	

}
