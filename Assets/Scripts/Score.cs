using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public GameObject camera;
    Text score_component;
    int init_height;
    int score;
	// Use this for initialization
	void Start () {
        init_height = (int)camera.transform.position.y;
        score_component = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        score = (int)((camera.transform.position.y - init_height) * 100);
	    score_component.text = "Score: "+ score;
	}
}
