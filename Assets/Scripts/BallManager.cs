﻿using UnityEngine;
using System.Collections.Generic;

public class BallManager : MonoBehaviour 
{
	public float ballTimer = 2f;
	public Vector3 spawnPosition;

	private Queue<GameObject> ballQueue = new Queue<GameObject>();

	private void Start()
	{
		ballQueue = new Queue<GameObject>();
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void EnQueue(GameObject gameObject)
	{
		// Disable the gameObject
		gameObject.SetActive(false);

		// Move the gameObject back to the spawn position
		gameObject.transform.position = spawnPosition;
		
		DeQueue();
	}

	private void DeQueue()
	{
		// TODO: Dequeue the immediate gameObject in the queue
		var ball = ballQueue.Dequeue();
		var timer = 0f;

		while (timer < ballTimer)
		{
			timer += Time.deltaTime;
		}

		ball.SetActive(true);
	}
}
