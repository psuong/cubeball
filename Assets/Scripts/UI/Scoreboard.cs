using UnityEngine;
using UnityEngine.UI;

public class Scoreboard: MonoBehaviour 
{
	public Text scoreText;

	private void Start()
	{
		Goal.earnEvent += UpdateScore;
	}

	private void OnDisable()
	{
		Goal.earnEvent -= UpdateScore;
	}

	private void UpdateScore(int score)
	{
		if (scoreText != null)
		{
			scoreText.text = string.Format("{0}", score);
		}
	}

}
