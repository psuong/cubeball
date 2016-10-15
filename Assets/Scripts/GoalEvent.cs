using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Goal Event", menuName = "Scriptable Objects/Goal Event")]
public class GoalEvent : ScriptableObject
{
	public delegate void OnGoalHandler(GameObject gameObject);
	private event OnGoalHandler onGoalEvent;

	public void Subscribe(OnGoalHandler goalHandler)
	{
		onGoalEvent -= goalHandler;
		onGoalEvent += goalHandler;
	}

	public void Unsubscribe(OnGoalHandler goalHandler) 
	{
		onGoalEvent -= goalHandler;
	}

	public void Invoke(GameObject gameObject)
	{
		if (onGoalEvent != null)
		{
			onGoalEvent(gameObject);
		}
	}
}
