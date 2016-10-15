using UnityEngine;
using System.Collections;
using System;

public class ProcessJSON : MonoBehaviour {
    [Serializable]
    public class Players
    {
        public string x0;
        public string x1;
        public string x2;
        public string x3;
        public string x4;
        public string x5;
        public string x6;
        public string x7;
    }
    [Serializable]
    public class PlayersWrapper
    {
        public Players[] players;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
