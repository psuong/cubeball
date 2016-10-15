using UnityEngine;
using System.Collections;

public class SpawnPlayers : MonoBehaviour {
    public GameObject playerPrefab;
    private FieldMatrix fieldMatrix;
    private bool[,] field;
    public int numberOfPlayers = 8;
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

    private void SpawnInField()
    {
        var spawnOffset = (x - numberOfPlayers/2) / 2;
        Debug.Log(numberOfPlayers / 2);
        for (int i = 0; i < numberOfPlayers/2; i++)
        {
            var centeringOffset = spawnOffset + i;
            var playerTeam1 = Instantiate(playerPrefab, new Vector3(centeringOffset, .5f, 1f), Quaternion.identity) as GameObject;
            SetTeamColor(playerTeam1, Color.red);
            field[centeringOffset, 1] = true;
            var playerTeam2 = Instantiate(playerPrefab, new Vector3(centeringOffset, .5f, z - 1), Quaternion.identity) as GameObject;
            SetTeamColor(playerTeam2, Color.blue);
            field[centeringOffset, z - 1] = true;
        }
    }
	
    private void SetTeamColor(GameObject go, Color color)
    {
        var goRenderer = go.GetComponent<Renderer>();
        goRenderer.material.color = color;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
