using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public GameObject camera;
    Text score_component;
    int init_height;
	// Use this for initialization
	void Start () {
        init_height = (int)camera.transform.position.y;
        score_component = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    score_component.text = "Score: "+(float)((int)((camera.transform.position.y - init_height)*100))/100;
	}
}
