using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Suelo : MonoBehaviour
{

    private MapGenerator mapGenerator;
    // Start is called before the first frame update
    void Start()
    {
        mapGenerator = transform.parent.Find("MapGenerator").GetComponent<MapGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Spawn Obstacles");
        mapGenerator.SwapwnObstacles();
    }
}
