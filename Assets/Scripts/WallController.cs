using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

    public GameObject[] walls_bottom;
    public GameObject[] walls_top;
    public GameObject[] torches;
    public GameObject camera;
    Camera camera_component;

    public GameObject platform;
    public float maxRight = 2;
    public float maxLeft = -2;
    public float maxheight = 2;
    public float torchDistance = 12;

    int platformsOnWall = 4;
    GameObject[] platforms = new GameObject[30];
    int numPlatform = 0;

	// Use this for initialization
	void Start () {
        walls_bottom = new GameObject[12];
        walls_bottom = GameObject.FindGameObjectsWithTag("Wall0");
        camera = GameObject.Find("Main Camera");
        camera_component = camera.GetComponent<Camera>();
        spawnPlatforms(0f, 18f, 16, 18);

        torches = new GameObject[4];
        torches = GameObject.FindGameObjectsWithTag("torches");   
    }
	
	// Update is called once per frame
	void Update () {
        //float viewPos = camera_component.WorldToViewportPoint()
        for (int i = 0; i < walls_bottom.Length; i++)
        {
            float obj_extent = GetObjectExtents(walls_bottom[i]);
            Vector3 target = new Vector3(camera.transform.position.x, walls_bottom[i].transform.position.y + obj_extent, 0f);
            Vector3 viewPos = camera_component.WorldToViewportPoint(target);
            if (viewPos.y < 0f)
            {
                walls_bottom[i].transform.position = new Vector3(walls_bottom[i].transform.position.x, walls_bottom[i].transform.position.y + obj_extent*2*3, walls_bottom[i].transform.position.z);
                //Spawn Plattforms
                float minY = walls_bottom[i].transform.position.y - obj_extent;
                float maxY = walls_bottom[i].transform.position.y + obj_extent;
                spawnPlatforms(minY, maxY, platformsOnWall, 6);
                
            }
        }

        for (int j = 0; j < torches.Length; j++)
        {
            float obj_extent2 = GetObjectExtents(torches[j]);
            Vector3 target2 = new Vector3(camera.transform.position.x, torches[j].transform.position.y + obj_extent2 + 3f, 0f);
            Vector3 viewPos2 = camera_component.WorldToViewportPoint(target2);
            if (viewPos2.y < 0f)
            {
                torches[j].transform.position = new Vector3(torches[j].transform.position.x, torches[j].transform.position.y + torchDistance, torches[j].transform.position.z);
            }
        }
	}

    float GetObjectExtents(GameObject gObj)
    {
        Bounds bounds = gObj.GetComponent<Collider>().bounds;
        return bounds.extents.y;
    }

    void spawnPlatforms(float minY, float maxY, int countP, float height)
    {
        Vector3 coords = new Vector3(-1,-1,-1);
        float distance = height / countP;
        for (int j = 0; j < countP; j++)
        {
            


            if (platforms[numPlatform] != null)
            {
                GameObject gObject = platforms[numPlatform];
                DestroyImmediate(gObject);
            }
            if (coords.y != -1)
            {
                float prevY = coords.y; 
                coords = new Vector3(Random.Range(maxLeft, maxRight),prevY + distance, -1);

            }
            else
            {
                coords = new Vector3(Random.Range(maxLeft, maxRight), minY + 1, -1);
            }

            GameObject newObject = Instantiate(platform, coords, platform.transform.rotation) as GameObject;
            newObject.transform.localScale = new Vector3(newObject.transform.localScale.x / Random.Range(0.4f, 3f), newObject.transform.localScale.y, newObject.transform.localScale.z);
            Debug.Log(newObject);
            platforms[numPlatform] = newObject;
            numPlatform++;
            numPlatform = numPlatform % 30;

        }
    }
}
