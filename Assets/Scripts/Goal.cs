using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Goal : MonoBehaviour 
{
	public delegate void OnEarnHandler(int score, Team team);
	public static event OnEarnHandler earnEvent;

	public string tagToCompare = "Ball";
	public Team team;
	public bool isColliderTrigger;

	[SerializeField]
	private Score score;
	[SerializeField]
	private GoalEvent goalEvent;
	private Collider collider;

	private void Start()
	{
		collider = GetComponent<Collider>();
		collider.isTrigger = isColliderTrigger;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(tagToCompare))
		{
			score.Earn();
			// Invoke the event
			if (earnEvent != null)
			{
				earnEvent(score.GetScore, team);
			}

			if (goalEvent != null)
			{
				goalEvent.Invoke(other.gameObject);
			}

#if UNITY_EDITOR_64 || UNITY_EDITOR

			Debug.LogWarningFormat("Score: {0}", score.GetScore);

#endif
		}
	}
}
