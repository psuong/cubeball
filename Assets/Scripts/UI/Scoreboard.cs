using UnityEngine;
using UnityEngine.UI;

public enum Team
{
	Red,
	Blue
}

public class Scoreboard: MonoBehaviour 
{
	public Text scoreText;
	public Team team;

	private void Start()
	{
		Goal.earnEvent += UpdateScore;
	}

	private void OnDisable()
	{
		Goal.earnEvent -= UpdateScore;
	}

	private void UpdateScore(int score, Team team)
	{
		if (scoreText != null)
		{
			if (this.team == team)
			{
				scoreText.text = string.Format("{0}", score);
			}
		}
	}

}
