using UnityEngine;
using System.Collections;

public class Continue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {

            GameObject.Find("Canvas").SendMessage("hideScoreScreen");
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}
