using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public int numberWalls;
    public GameObject wall;
    public float minDistanceObstacles;
    public NavMeshSurface surface;
    int direction = 0;
    public GameObject suelo;
    Vector3 previous_obstacle;
    public int min_size;
    public int max_size;
    public List<GameObject> walls;
    public float sizeObstacles=1f;
    RaycastHit hit;
    void Start()
    {
        suelo = transform.parent.Find("NavMesh").Find("Suelo").gameObject;
        surface = transform.parent.Find("NavMesh").GetComponent<NavMeshSurface>();
        walls = new List<GameObject>();
        SwapwnObstacles();
    }

    private bool CorrectDistance(Vector3 position)
    {
        bool isOkay = true;
        for(int i = 0; i < walls.Count; i++)
        {
            float distancePosition = Vector3.Distance(position, walls[i].transform.position);
            if (distancePosition < minDistanceObstacles)
            {
                isOkay = false;
            }

        }
        return isOkay;
    }
    

    
    private void Spawn()
    {
        int tryes = 0;
        float rndScaleX = Random.Range(min_size, max_size);
        float rndScaleY = 3;
        float rndScaleZ = Random.Range(min_size, max_size);

        float rndPosX = Random.Range(-18, 18);
        float rndPosZ = Random.Range(-23, 23);
        Vector3 newPos = new Vector3(rndPosX, 1.5f, rndPosZ) + suelo.transform.position;
        Vector3 newScale = new Vector3(rndScaleX, rndScaleY, rndScaleZ);
        
        while(tryes<10000 && !CorrectDistance(newPos))
        {
            rndPosX = Random.Range(-18, 18);
            rndPosZ = Random.Range(-23, 23);

            rndScaleX = Random.Range(min_size, max_size);
            rndScaleY = 3;
            rndScaleZ = Random.Range(min_size, max_size);

            direction = Random.Range(1, 2);

            newPos = new Vector3(rndPosX, 1.5f, rndPosZ) + suelo.transform.position;
            newScale = new Vector3(rndScaleX, rndScaleY, rndScaleZ);
            tryes++;
        }
        if (tryes == 10000)
        {
            Debug.Log("Loop from Map Generator break");
        }
        GameObject myWall = Instantiate(wall, newPos, Quaternion.identity, transform.parent.Find("NavMesh")) as GameObject;
        myWall.transform.localScale = newScale;
        
        walls.Add(myWall);



    }

    

    public void Clear()
    {
        for (int i = 0; i < walls.Count; i++)
        {
            Destroy(walls[i].gameObject);
            
        }
        walls.Clear();
    }
    public void SwapwnObstacles()
    {
        Clear();
        for (int i = 0; i < numberWalls; i++)
        {
            Spawn();
            
        }
        surface.BuildNavMesh();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
