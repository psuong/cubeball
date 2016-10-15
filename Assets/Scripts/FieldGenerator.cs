using UnityEngine;
using System.Collections;

public class FieldGenerator : MonoBehaviour {
    private int x;
    private int z;
    public GameObject fieldSquare;

    void OnEnable()
    {
        x = GetComponent<FieldMatrix>().x;
        z = GetComponent<FieldMatrix>().z;
    }


	// Use this for initialization
	void Start () {
        SetupField();
	
	}

    private void SetupField()
    {
        for(int i = 0; i < x; i ++)
        {
            for(int j = 0; j <=z; j++)
            {
                var tile = Instantiate(fieldSquare);
                var fieldRenderer = tile.GetComponent<Renderer>();
                fieldRenderer.material.color = Color.green;
                tile.transform.position = new Vector3(i, 0, j);
            }
        }
        for(int zplace = -1; zplace<= z+1; zplace++)
        {
            var outterTile = Instantiate(fieldSquare);
            var renderer = outterTile.GetComponent<Renderer>();
            outterTile.transform.position = new Vector3(-1f, 0f, zplace);

            var otherOutterTile = Instantiate(fieldSquare);
            otherOutterTile.transform.position = new Vector3(x, 0f, zplace);
            var otherRenderer = otherOutterTile.GetComponent<Renderer>();
            renderer.material.color = Color.black;
            otherRenderer.material.color = Color.black;
        }

        for(int xplace = -1;xplace <x; xplace++)
        {
            var outTile = Instantiate(fieldSquare);
            var outRenderer = outTile.GetComponent<Renderer>();
            outTile.transform.position = new Vector3(xplace, 0f, -1f);
            outRenderer.material.color = Color.black;
            var outTile2 = Instantiate(fieldSquare);
            var outRenderer2 = outTile2.GetComponent<Renderer>();
            outTile2.transform.position = new Vector3(xplace, 0f, z+1);
            outRenderer2.material.color = Color.black;

        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
