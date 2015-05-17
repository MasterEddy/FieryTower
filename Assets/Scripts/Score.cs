using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public GameObject camera;
    public GameObject score_obj;
    public GameObject es_score;
    public GameObject es_image;
    public GameObject es_continue;
    Text score_component;
    Text es_score_component;
    Text es_continue_component;
    Image es_image_component;
    int init_height;
    int score;
	// Use this for initialization
	void Start () {
        init_height = (int)camera.transform.position.y;
        score_component = score_obj.GetComponent<Text>();
        es_score_component = es_score.GetComponent<Text>();
        es_continue_component = es_continue.GetComponent<Text>();
        es_image_component = es_image.GetComponent<Image>();

        es_score.SetActive(false);
        es_image.SetActive(false);
        es_continue.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        score = (int)((camera.transform.position.y - init_height) * 100);
	    score_component.text = "Score: "+ score;
	}

    void ScoreScreen()
    {
        Time.timeScale = 0;
        score_obj.SetActive(false);
        es_image.SetActive(true);
        es_score.SetActive(true);
        es_continue.SetActive(true);
        es_score_component.text = "Your Score:\n" + score;
        Debug.Log("SHOW SCREEN");
    }
    void hideScoreScreen()
    {
        Time.timeScale = 1;
        score_obj.SetActive(true);
        score_component.text = "Score: 0";
        es_image.SetActive(false);
        es_score.SetActive(false);
        es_continue.SetActive(false);
    }
}
