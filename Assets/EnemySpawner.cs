using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public EnemyManager enemyManager;

    [Header("Max Environment Steps")] public int MaxEnvironmentSteps = 4000;
    public GameObject suelo;
    public MapGenerator mapGenerator;
    public int NumAgents;

    private Team Team;
    public ShootingAgent Agent_Team1;
    public ShootingAgent Agent_Team2;

    private int m_ResetTimer;
    public SimpleMultiAgentGroup m_AgentGroup1;
    public SimpleMultiAgentGroup m_AgentGroup2;
    public Material winMaterial;
    public MeshRenderer floor;
    public Material loseMaterial;
    public Material defaultMaterial;
    public PlayerController playerController;
    void Start()
    {


        Team = transform.parent.Find("Teams").Find("Team1").GetComponent<Team>();
        Team.TeamId = 1;

        for (int i = 0; i < NumAgents; i++)
        {
            ;
            ShootingAgent myAgentTeam = Instantiate<ShootingAgent>(Agent_Team1, new Vector3(0, 0, 0), Quaternion.identity, Team.transform);
            myAgentTeam.Team = Team;
            Team.AgentsList.Add(myAgentTeam);
        }
        Team.m_NumberOfRemainingPlayers = Team.getActiveAgents();

        mapGenerator = transform.parent.Find("MapGenerator").GetComponent<MapGenerator>();



        // Initialize TeamManager
        m_AgentGroup1 = new SimpleMultiAgentGroup();




        foreach (var agent in Team.AgentsList)
        {
            agent.ResetAgent();
            // Add to team manager
            m_AgentGroup1.RegisterAgent(agent);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_ResetTimer += 1;
        if (m_ResetTimer >= MaxEnvironmentSteps && MaxEnvironmentSteps > 0)
        {
            m_AgentGroup1.AddGroupReward(-0.5f);
            m_AgentGroup1.EndGroupEpisode();
            ResetScene();
            floor.material = defaultMaterial;

        }
    }

    public void AgentKilled(ShootingAgent agent)
    {
        Team currentTeam = agent.Team;
        currentTeam.m_NumberOfRemainingPlayers -= 1;
        if (currentTeam.m_NumberOfRemainingPlayers <= 0)
        {
            if (currentTeam.TeamId == 2)
            {
                floor.material = loseMaterial;
                m_AgentGroup1.AddGroupReward(1f);
                m_AgentGroup1.EndGroupEpisode();
                ResetScene();


            }
            else if (currentTeam.TeamId == 1)
            {
                floor.material = winMaterial;
                m_AgentGroup1.AddGroupReward(-1f);
                m_AgentGroup1.EndGroupEpisode();
                ResetScene();
            }




        }
    }





    public void ResetScene()
    {
        playerController.transform.position = playerController.startingPosition;
        playerController.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        foreach (var agent1 in Team.AgentsList)
        {
            agent1.gameObject.SetActive(true);
            agent1.ResetAgent();
            // Add to team manager
            m_AgentGroup1.RegisterAgent(agent1);
        }

        //Reset counter
        m_ResetTimer = 0;


        Team.m_NumberOfRemainingPlayers = Team.getActiveAgents();

        mapGenerator.SwapwnObstacles();

    }



}
