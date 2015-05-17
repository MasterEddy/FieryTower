using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject camera;
    public float SPEED = 0.1f;
    public Vector3 moveUp;


	// Use this for initialization
	void Start () {
        moveUp = new Vector3(0f, 1f, 0f) * SPEED;
        camera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        camera.transform.Translate(moveUp * Time.deltaTime);
	}
}
