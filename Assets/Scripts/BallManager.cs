using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallManager : MonoBehaviour 
{
	public float ballTimer = 2f;
	public Vector3 spawnPosition;

	[SerializeField]
	private GoalEvent goalEvent;

	private Queue<GameObject> ballQueue;
	private Coroutine routine;

	private void Start()
	{
		ballQueue = new Queue<GameObject>();
	}

	private void OnEnable()
	{
		goalEvent.Subscribe(EnQueue);
	}

	private void OnDisable()
	{
		goalEvent.Unsubscribe(EnQueue);
	}

	private void EnQueue(GameObject gameObject)
	{
		// Disable the gameObject
		gameObject.SetActive(false);

		// Move the gameObject back to the spawn position
		gameObject.transform.position = spawnPosition;
		ballQueue.Enqueue(gameObject);
		DeQueue();
	}

	private void DeQueue()
	{
		if (routine == null)
		{
			routine = StartCoroutine(BallTimer());
		}
	}

	private IEnumerator BallTimer()
	{
		yield return new WaitForSeconds(ballTimer);
		var ball = ballQueue.Dequeue();
		ball.SetActive(true);

		routine = null;
	}
}
