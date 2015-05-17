using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

    public GameObject[] walls_bottom;
    public GameObject[] walls_top;

	// Use this for initialization
	void Start () {
        walls_bottom = new GameObject[2];
        walls_top = new GameObject[2];
        walls_bottom = GameObject.FindGameObjectsWithTag("Wall0");
        walls_top = GameObject.FindGameObjectsWithTag("Wall1");
	}
	
	// Update is called once per frame

	void Update () {
        
            for (int i = 0; i < walls_bottom.Length; i++)
            {
                //walls_bottom[i].transform.Translate(-moveUp);
                //walls_top[i].transform.Translate(-moveUp);
                if (walls_bottom[i].transform.position.y < GetComponent<Camera>().transform.position.y - 7f)
                {
                    walls_bottom[i].transform.position = new Vector3(walls_bottom[i].transform.position.x, GetComponent<Camera>().transform.position.y + 1.95f, walls_bottom[i].transform.position.z);
                }
            }
	}
}
