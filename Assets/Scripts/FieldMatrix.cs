using UnityEngine;
using System.Collections;


public class FieldMatrix : MonoBehaviour {
    private bool[,] field;
    public bool[,] playingfield { get { return field; } }
    public int x= 6;
    public int z = 20;

         
	// Use this for initialization
	void OnEnable () {
        field = new bool[x, z];    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
