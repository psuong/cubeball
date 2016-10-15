using UnityEngine;
using System.Collections;

public class GoalEvent : ScriptableObject
{
	private delegate void OnGoalHandler(GameObject gameObject);
	private event OnGoalHandler onGoalEvent;

	public void Subscribe()
	{
	}

	public void Unsubscribe()
	{
	}

	public void Invoke(GameObject gameObject)
	{
	}
}
