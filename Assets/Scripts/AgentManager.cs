using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    // Start is called before the first frame update

    public EnemyManager enemyManager;

    [Header("Max Environment Steps")] public int MaxEnvironmentSteps = 4000;
    public GameObject suelo;
    public MapGenerator mapGenerator;
    public int NumAgents;

    public ShootingAgent Agent;
    private Transform Agents;

    public int m_NumberOfRemainingPlayers;
    public List<ShootingAgent> AgentsList = new List<ShootingAgent>();
    private int m_ResetTimer;
    public SimpleMultiAgentGroup m_AgentGroup;
    public Material winMaterial;
    public MeshRenderer floor;
    public Material loseMaterial;
    void Start()
    {
        
        Agents = transform.parent.Find("Agents");
        for (int i = 0; i < NumAgents; i++)
        {
            ShootingAgent myAgent = Instantiate<ShootingAgent>(Agent, new Vector3(0, 0, 0), Quaternion.identity, Agents);
            AgentsList.Add(myAgent);
        }
        enemyManager = transform.parent.Find("EnemyManager").GetComponent<EnemyManager>();
        enemyManager.ResetEnemies();

        suelo = transform.parent.Find("NavMesh").Find("Suelo").gameObject;
        m_NumberOfRemainingPlayers = getActiveAgents();
        mapGenerator = transform.parent.Find("MapGenerator").GetComponent<MapGenerator>();



        // Initialize TeamManager
        m_AgentGroup = new SimpleMultiAgentGroup();
        

        foreach (var agent in AgentsList)
        {
            agent.ResetAgent();
            // Add to team manager
            m_AgentGroup.RegisterAgent(agent);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_ResetTimer += 1;
        if (m_ResetTimer >= MaxEnvironmentSteps && MaxEnvironmentSteps > 0)
        {
            m_AgentGroup.GroupEpisodeInterrupted();
            ResetScene();
        }
    }

    public void AgentKilled(Transform agent)
    {
        agent.gameObject.SetActive(false);
        m_NumberOfRemainingPlayers--;
        if (m_NumberOfRemainingPlayers == 0)
        {
            floor.material = loseMaterial;
            ResetScene();
            m_AgentGroup.AddGroupReward(-1f);
            m_AgentGroup.EndGroupEpisode();

        }
    }

    

   

    public void ResetScene()
    {

        //Reset counter
        m_ResetTimer = 0;

        //Reset Players Remainingm_NumberOfRemainingPlayers
        

        //Reset Agents
        foreach (var agent in AgentsList)
        {
            agent.gameObject.SetActive(true);
            agent.ResetAgent();
            m_AgentGroup.RegisterAgent(agent);
        }
        m_NumberOfRemainingPlayers = getActiveAgents();
        mapGenerator.SwapwnObstacles();
        enemyManager.ResetEnemies();

    }
    

    private int getActiveAgents()
    {
        int counter = 0;
        for(int i = 0; i < Agents.childCount; i++)
        {
            if (Agents.GetChild(i).gameObject.activeInHierarchy)
            {
                counter++;
            }
        }
        return counter;
    }
}

