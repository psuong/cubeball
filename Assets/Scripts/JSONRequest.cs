using UnityEngine;
using System.Collections;

public class JSONRequest : MonoBehaviour 
{
	[Tooltip("How often do we ping the server?")]
	public float intervalTimer = 2f;

#region Accessors
	[SerializeField, TextArea]
	public string JSONData;

#endregion
#region Private Fields

	private float internalTimer;
	[SerializeField]
	private string URL;
	private WWW wwwObject;

	private Coroutine urlRequest;

#endregion

	private void Start()
	{
		internalTimer = intervalTimer;
	}

	private void Update()
	{
		internalTimer -= Time.deltaTime;
		if (internalTimer < 0)
		{
			internalTimer = 0f;
			if (urlRequest == null)
			{
				urlRequest = StartCoroutine(RequestURL());
			}
		}
	}

	private IEnumerator RequestURL()
	{
		wwwObject = new WWW(URL);
		yield return wwwObject;
		JSONData = wwwObject.text;

		urlRequest = null;
		Debug.LogFormat("JSON: {0}", wwwObject.text);
	}
}
