using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {
    private bool[,] fieldMatrix;
    public float movementInterval = 1f;
    private Players playerInputs;
    private GameObject[] players;
    private bool isPlaying = true;


	// Use this for initialization
	void Start () {
        fieldMatrix = GetComponent<FieldMatrix>().playingfield;
        playerInputs = GetComponent<ProcessJSON>().wrapper.players[0];
        players = GameObject.FindGameObjectsWithTag("Player");
        StartCoroutine("movementUpdater");
	}


    private void MovePlayer(int i , string instruction)
    {
        var goalPosition = transform.position + GetOffsetVector(instruction);
        try
        {
            if(fieldMatrix[(int)goalPosition.x,(int)goalPosition.z] == false)
            {
                fieldMatrix[(int)transform.position.x, (int)transform.position.z] = true;
                players[i].transform.position = Vector3.MoveTowards(transform.position, goalPosition, 1f);
                fieldMatrix[(int)transform.position.x, (int)transform.position.z] = false;
            }
            
        }
        catch(IndexOutOfRangeException)
        {

        }
    }

    private void UpdateInputs()
    {
        playerInputs = GetComponent<ProcessJSON>().wrapper.players[0];
    }

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

    private IEnumerator movementUpdater()
    {
        while( isPlaying == true)
        {
            yield return new WaitForSeconds(movementInterval);
            UpdateInputs();
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



    // Update is called once per frame
    void Update () {
	
	}
}
