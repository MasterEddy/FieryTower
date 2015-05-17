using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    public GameObject platform;
    public float timer = 3.0f;
    float incY = 1;
    Vector3 start = new Vector3(0f, 2f, -1f);
    bool inGame;
    GameObject[] platforms = new GameObject[20];
    public float maxRight = 2;
    public float maxLeft = -2;
    public float maxheight = 2;

	// Use this for initialization
	void Start () {
        inGame = true;
        StartCoroutine("CreatePlatform");
	}
	
	// Update is called once per frame
	void Update () {


	
	}

    IEnumerator CreatePlatform()
    {
        int numPlatform = 0;
        while (inGame)
        {
            // Yield coroutine
            yield return new WaitForSeconds(timer);
            if (platforms[numPlatform] != null)
            {
                GameObject gObject = platforms[numPlatform];
                DestroyImmediate(gObject);
            }
            GameObject newObject = Instantiate(platform, start, platform.transform.rotation) as GameObject;
            newObject.transform.localScale = new Vector3( newObject.transform.localScale.x / Random.Range(0.4f,3f), newObject.transform.localScale.y, newObject.transform.localScale.z);
            Debug.Log(newObject);
            platforms[numPlatform] = newObject;
            numPlatform++;
            numPlatform = numPlatform % 20;
            start.y += Random.Range(incY,maxheight);
            start.x = Random.Range(maxLeft,maxRight);
        }
       
    }
}
