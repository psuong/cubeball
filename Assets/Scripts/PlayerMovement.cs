using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
