﻿using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

    public GameObject[] walls_bottom;
    public GameObject[] walls_top;
    public GameObject camera;
    public Vector3 moveUp;
    public float SPEED = 0.1f;
	// Use this for initialization
	void Start () {
        moveUp = new Vector3(0f, 1f, 0f)*SPEED;
        walls_bottom = new GameObject[2];
        walls_top = new GameObject[2];
        walls_bottom = GameObject.FindGameObjectsWithTag("Wall0");
        walls_top = GameObject.FindGameObjectsWithTag("Wall1");
        camera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        camera.transform.Translate(moveUp * Time.deltaTime);
            for (int i = 0; i < walls_bottom.Length; i++)
            {
                //walls_bottom[i].transform.Translate(-moveUp);
                //walls_top[i].transform.Translate(-moveUp);
                if (walls_bottom[i].transform.position.y < camera.transform.position.y - 1f)
                {
                    walls_bottom[i].transform.position = new Vector3(walls_bottom[i].transform.position.x, camera.transform.position.y + 1.95f, walls_bottom[i].transform.position.z);
                }
            }
	}
}
