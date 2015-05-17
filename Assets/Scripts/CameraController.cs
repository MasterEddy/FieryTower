using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject camera;
    public float SPEED = 0.1f;
    public Vector3 moveUp;
    public Vector3 addSpeed = new Vector3(0f, 0.1f, 0f);

    float accumulator = 0.0f;
    float waitTime = 1.0f;



    // Use this for initialization
    void Start()
    {
        moveUp = new Vector3(0f, 1f, 0f) * SPEED;
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {

        camera.transform.Translate(moveUp * Time.deltaTime);

        // Timer for perodic speed increase
        accumulator += Time.deltaTime;
        if (accumulator >= waitTime)
        {
            moveUp += addSpeed;
            accumulator = 0f;
        }
    }
}
