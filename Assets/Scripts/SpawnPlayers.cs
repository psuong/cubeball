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
	void Start () {
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
            var playerTeam1 = Instantiate(playerPrefab, new Vector3(centeringOffset, .5f, 1f), Quaternion.identity);
            field[centeringOffset, 1] = true;
            var playerTeam2 = Instantiate(playerPrefab, new Vector3(centeringOffset, .5f, z - 1), Quaternion.identity);
            field[centeringOffset, z - 1] = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
