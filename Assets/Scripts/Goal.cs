using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Goal : MonoBehaviour 
{
	public string tagToCompare = "Ball";
	public bool isColliderTrigger;

	[SerializeField]
	private Score score;
	private Collider collider;

	private void Start()
	{
		collider = GetComponent<Collider>();
		collider.isTrigger = isColliderTrigger;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (score != null)
		{
			if (other.CompareTag(tagToCompare))
			{

				score.Earn();

#if UNITY_EDITOR_64 || UNITY_EDITOR
				Debug.LogFormat("Score: {0}", score.GetScore);
#endif
			}
		}
	}
}
