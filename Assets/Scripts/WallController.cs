using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

    public GameObject[] walls_bottom;
    public GameObject[] walls_top;
    public GameObject camera;
    Camera camera_component;
	// Use this for initialization
	void Start () {
        walls_bottom = new GameObject[12];
        walls_bottom = GameObject.FindGameObjectsWithTag("Wall0");
        camera = GameObject.Find("Main Camera");
        camera_component = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        //float viewPos = camera_component.WorldToViewportPoint()
        for (int i = 0; i < walls_bottom.Length; i++)
        {
            Vector3 target = new Vector3(camera.transform.position.x, walls_bottom[i].transform.position.y - GetObjectExtents(walls_bottom[i]), camera.transform.position.z + 1f);
            Vector3 viewPos = camera_component.WorldToViewportPoint(target);
            Debug.Log(viewPos);
            //walls_bottom[i].transform.Translate(-moveUp);
            //walls_top[i].transform.Translate(-moveUp);
            if (walls_bottom[i].transform.position.y < camera.transform.position.y - 7f)
            {
                walls_bottom[i].transform.position = new Vector3(walls_bottom[i].transform.position.x, camera.transform.position.y + 1.95f, walls_bottom[i].transform.position.z);
            }
        }
	}

    float GetObjectExtents(GameObject gObj)
    {
        Bounds bounds = gObj.GetComponent<Collider>().bounds;
        return bounds.extents.y;
    }
}
