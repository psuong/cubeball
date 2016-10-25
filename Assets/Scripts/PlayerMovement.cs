using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {
    private bool[,] fieldMatrix;
    public float movementInterval = 1f;
    private Players playerInputs = new Players();
    private bool isPlaying = true;
    private JSONRequest jsonRequest;
    [SerializeField]
    private GameObject[] players;


	// Use this for initialization
	void Start () {
        fieldMatrix = GetComponent<FieldMatrix>().playingfield;
        players = GameObject.FindGameObjectsWithTag("Player");
        jsonRequest = GetComponent<JSONRequest>();
        StartCoroutine(movementUpdater());
    }

	/// <summary>
	/// Moves the player based on the instruction and updates field matrix
	/// </summary>
	/// <param name="i">The index.</param>
	/// <param name="instruction">Instruction.</param>
    private void MovePlayer(int i , string instruction)
    {
        var goalPosition = players[i].transform.position + GetOffsetVector(instruction);
        try
        {
            if(fieldMatrix[(int)goalPosition.x,(int)goalPosition.z] == false)
            {
                fieldMatrix[(int)players[i].transform.position.x, (int)players[i].transform.position.z] = false;

                players[i].transform.position = Vector3.MoveTowards(players[i].transform.position, goalPosition, 1f);
                fieldMatrix[(int)goalPosition.x, (int)goalPosition.z] = true;

            }

        }
        catch(IndexOutOfRangeException)
        {

        }
    }

	/// <summary>
	/// Reads the latest json string to update the player wrapper and get the latest instructions 
	/// </summary>
	/// <returns>The player inputs.</returns>
	/// <param name="JSONstring">JSON string.</param>
    public PlayersWrapper UpdatePlayerInputs(string JSONstring)
    {
        if (JSONstring != string.Empty) {
            return JsonUtility.FromJson<PlayersWrapper>(JSONstring);

        }
        return null;
    }

	/// <summary>
	/// Gets the offset vector for the space that player needs to move.
	/// </summary>
	/// <returns>The offset vector.</returns>
	/// <param name="instruction">Instruction from player</param>
    private Vector3 GetOffsetVector(string instruction)
    {
        var x = 0;
        var z = 0;

        switch (instruction)
        {
            case ("w"):
                x -= 1;
                break;
            case ("a"):
                z -= 1;
                break;
            case ("s"):
                x += 1;
                break;
            case ("d"):
                z += 1;
                break;
            default:
                break;
        }

        return new Vector3(x, 0, z);
    }

	/// <summary>
	/// Updates new player locations at specified interval 
	/// </summary>
	/// <returns>The updater.</returns>
    private IEnumerator movementUpdater()
    {
        while( isPlaying == true)
        {
            yield return new WaitForSeconds(movementInterval);
            while (jsonRequest.JSONData == string.Empty)
            {
                // Wait until there is actually a string to process
                yield return null;
            }
            playerInputs = UpdatePlayerInputs(jsonRequest.JSONData).players[0];
            MovePlayer(0, playerInputs.x0);
            MovePlayer(1, playerInputs.x1);
            MovePlayer(2, playerInputs.x2);
            MovePlayer(3, playerInputs.x3);
            MovePlayer(4, playerInputs.x4);
            MovePlayer(5, playerInputs.x5);
            MovePlayer(6, playerInputs.x6);
            MovePlayer(7, playerInputs.x7);

        }

    }
		
}
