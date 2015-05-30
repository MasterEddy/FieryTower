using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public GameObject camera;
    public GameObject score_obj;
    public GameObject es_score;
    public GameObject es_image;
    public GameObject es_button1;
    public GameObject es_button2;
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
        es_image_component = es_image.GetComponent<Image>();

        es_score.SetActive(false);
        es_image.SetActive(false);
        es_button1.SetActive(false);
        es_button2.SetActive(false);

        //Disbale Mouse Cursor
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        score = (int)((camera.transform.position.y - init_height) * 100);
	    score_component.text = "Score: "+ score;
	}

    void ScoreScreen()
    {
        //Disbale Mouse Cursor
        Cursor.visible = true;
        Time.timeScale = 0;
        score_obj.SetActive(false);
        es_image.SetActive(true);
        es_score.SetActive(true);
        es_button1.SetActive(true);
        es_button2.SetActive(true);
        es_score_component.text = "Your Score:\n" + score;
        Debug.Log("SHOW SCREEN");
    }
    public void hideScoreScreen()
    {
        //Disbale Mouse Cursor
        Cursor.visible = false;
        Time.timeScale = 1;
        score_obj.SetActive(true);
        score_component.text = "Score: 0";
        es_image.SetActive(false);
        es_score.SetActive(false);
        es_button1.SetActive(false);
        es_button2.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel("MainMenu");
    }
}
