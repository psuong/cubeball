using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {
    private bool[,] fieldMatrix;


	// Use this for initialization
	void Start () {
        fieldMatrix = GetComponent<FieldMatrix>().playingfield;
	}

    private void MovePlayer(string instruction)
    {
        var goalPosition = transform.position + GetOffsetVector(instruction);
        try
        {
            if(fieldMatrix[(int)goalPosition.x,(int)goalPosition.z] == false)
            {
                fieldMatrix[(int)transform.position.x, (int)transform.position.z] = true;
                transform.position = Vector3.MoveTowards(transform.position, goalPosition, 1f);
                fieldMatrix[(int)transform.position.x, (int)transform.position.z] = false;
            }
            
        }
        catch(IndexOutOfRangeException)
        {

        }
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


	
	// Update is called once per frame
	void Update () {
	
	}
}
