﻿using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Score", menuName = "Scriptable Objects/Score")]
public class Score : ScriptableObject
{
	private uint score = 0;

	public void Earn()
	{
		score++;
	}

	public void Spend()
	{
		if (score < 1)
			return;
		score--;
	}

	public void Reset()
	{
		score = 0;
	}
}
