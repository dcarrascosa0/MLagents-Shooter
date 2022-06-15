using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    // Start is called before the first frame update
    public List<ShootingAgent> AgentsList = new List<ShootingAgent>();
    public int m_NumberOfRemainingPlayers;
    public int TeamId;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getActiveAgents()
    {
        int counter = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeInHierarchy)
            {
                counter++;
            }
        }
        return counter;
    }
}
