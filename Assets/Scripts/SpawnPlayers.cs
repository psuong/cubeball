using UnityEngine;
using System.Collections;

public class SpawnPlayers : MonoBehaviour {
	
	public int numberOfPlayers = 8;
    public GameObject playerPrefab;

	// Private field vales 
    private FieldMatrix fieldMatrix;
    private bool[,] field;
    private int x;
    private int z;
    

	// Use this for initialization
	void OnEnable () {
        fieldMatrix = GetComponent<FieldMatrix>();
        field = fieldMatrix.playingfield;
        x = fieldMatrix.x;
        z = fieldMatrix.z;
        SpawnInField();
	}

	/// <summary>
	/// Alternatingly spawns the player cubes in the field so team players are odd/even numbered. 
	/// </summary>
    private void SpawnInField()
    {
        var spawnOffset = (x - numberOfPlayers/2) / 2;
        Debug.Log(numberOfPlayers / 2);
        var j = 0;
        for (int i = 0; i < numberOfPlayers/2; i++)
        {
            var centeringOffset = spawnOffset + i;
            var playerTeam1 = Instantiate(playerPrefab, new Vector3(centeringOffset, .5f, 1f), Quaternion.identity) as GameObject;
            SetTeamColor(playerTeam1, Color.red);
            SetPlayerNumber(playerTeam1, j);
            field[centeringOffset, 1] = true; // update the matrix that this location is occupied 

            var playerTeam2 = Instantiate(playerPrefab, new Vector3(centeringOffset, .5f, z - 1), Quaternion.identity) as GameObject;
            SetTeamColor(playerTeam2, Color.blue);
            field[centeringOffset, z - 1] = true;
            SetPlayerNumber(playerTeam2, ++j);
            ++j;
        }
    }

	/// <summary>
	/// Sets the player number on the cube ( numbering starts from 1)
	/// </summary>
	/// <param name="go">Go.</param>
	/// <param name="playerindex">Playerindex.</param>
    private void SetPlayerNumber(GameObject go, int playerindex)
    {
        var textMesh = go.GetComponentInChildren<TextMesh>();
        textMesh.text = (playerindex + 1).ToString();
    }

	/// <summary>
	/// Sets the color of player cube to desired color
	/// </summary>
	/// <param name="go">Go.</param>
	/// <param name="color">Color.</param>
    private void SetTeamColor(GameObject go, Color color)
    {
        var goRenderer = go.GetComponent<Renderer>();
        goRenderer.material.color = color;
    }
}
