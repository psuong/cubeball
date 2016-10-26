// Initializes the playing field matrix to keep track of what spaces are filled in the field
using UnityEngine;
using System.Collections;


public class FieldMatrix : MonoBehaviour {
    private bool[,] field;
    public bool[,] playingfield { get { return field; } }
    public int x= 6;
    public int z = 20;

             
	void OnEnable () {
        field = new bool[x, z];    
	}

}
