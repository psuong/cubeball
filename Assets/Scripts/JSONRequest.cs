using UnityEngine;
using System.Collections;

public class JSONRequest : MonoBehaviour 
{
	[Tooltip("How often do we ping the server?")]
	public float intervalTimer = 2f;

	private float internalTimer;
	[SerializeField]
	private string URL;
	private WWW wwwObject;

	private Coroutine urlRequest;

	private void Start()
	{
		internalTimer = intervalTimer;
	}

	private void Update()
	{
		internalTimer -= Time.deltaTime;
		if (internalTimer < 0)
		{
			// TODO: Reset the timer
			// TODO: Request the URL
		}
	}

	private IEnumerator RequestURL()
	{
		wwwObject = new WWW(URL);
		yield return wwwObject;

		Debug.LogFormat("JSON: {0}", wwwObject.text);
	}
}
