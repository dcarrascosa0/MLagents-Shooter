using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    // Start is called before the first frame update

    public EnemyManager enemyManager;

    [Header("Max Environment Steps")] public int MaxEnvironmentSteps;
    public GameObject suelo;
    public MapGenerator mapGenerator;
    public int NumAgents;

    private Team Team1;
    private Team Team2;
    public ShootingAgent Agent_Team1;
    public ShootingAgent Agent_Team2;

    private int m_ResetTimer;
    public SimpleMultiAgentGroup m_AgentGroup1;
    public SimpleMultiAgentGroup m_AgentGroup2;
    public Material winMaterial;
    public MeshRenderer floor;
    public Material loseMaterial;
    public Material defaultMaterial;

    public bool isReady;
    public bool isTraining;
    public List<int> deadInstances;


    void Start()
    {
        isReady = true;
        Team1 = transform.parent.Find("Teams").Find("Team1").GetComponent<Team>();
        Team1.TeamId = 1;
        Team2 = transform.parent.Find("Teams").Find("Team2").GetComponent<Team>();
        Team2.TeamId = 2;

        for (int i = 0; i < NumAgents; i++)
        {
            ShootingAgent myAgentTeam1 = Instantiate<ShootingAgent>(Agent_Team1, new Vector3(0, 0, 0), Quaternion.identity, Team1.transform);
            myAgentTeam1.Team = Team1;
            Team1.AgentsList.Add(myAgentTeam1);
            ShootingAgent myAgentTeam2 = Instantiate<ShootingAgent>(Agent_Team2, new Vector3(0, 0, 0), Quaternion.identity, Team2.transform);
            myAgentTeam2.Team = Team2;
            Team2.AgentsList.Add(myAgentTeam2);
        }
        Team1.m_NumberOfRemainingPlayers = Team1.getActiveAgents();
        Team2.m_NumberOfRemainingPlayers = Team2.getActiveAgents();

        mapGenerator = transform.parent.Find("MapGenerator").GetComponent<MapGenerator>();



        // Initialize TeamManager
        m_AgentGroup1 = new SimpleMultiAgentGroup();
        m_AgentGroup2 = new SimpleMultiAgentGroup();



        foreach (var agent in Team1.AgentsList)
        {
            agent.ResetAgent();
            // Add to team manager
            m_AgentGroup1.RegisterAgent(agent);
        }
        foreach (var agent in Team2.AgentsList)
        {
            agent.ResetAgent();
            // Add to team manager
            m_AgentGroup2.RegisterAgent(agent);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_ResetTimer += 1;
        if (m_ResetTimer >= MaxEnvironmentSteps && MaxEnvironmentSteps > 0)
        {
            if (isTraining)
            {
                m_AgentGroup1.SetGroupReward(0f);
                m_AgentGroup2.SetGroupReward(0f);
            }
            
            m_AgentGroup1.EndGroupEpisode();
            m_AgentGroup2.EndGroupEpisode();
            floor.material = defaultMaterial;
            ResetScene();

        }
    }
    public void AgentKilled(ShootingAgent agent)
    {
        if (!deadInstances.Contains(agent.GetInstanceID()))
        {
            deadInstances.Add(agent.GetInstanceID());
            agent.Team.m_NumberOfRemainingPlayers -= 1;
            if (agent.Team.m_NumberOfRemainingPlayers <= 0)
            {
                Transform teams = transform.parent.Find("Teams");

                for (int i = 0; i < teams.childCount; i++)
                {
                    if ((teams.GetChild(i).transform.tag == "projectile1") || (teams.GetChild(i).transform.tag == "projectile2"))
                    {
                        Destroy(teams.GetChild(i).gameObject);
                    }
                }
                isReady = false;
                if (agent.Team.TeamId == 1)
                {
                    floor.material = loseMaterial;
                    if (isTraining)
                    {
                        m_AgentGroup1.SetGroupReward(-1f);
                        m_AgentGroup2.SetGroupReward(1f);
                    }

                    m_AgentGroup1.EndGroupEpisode();
                    m_AgentGroup2.EndGroupEpisode();
                    ResetScene();


                }
                else if (agent.Team.TeamId == 2)
                {
                    floor.material = winMaterial;
                    if (isTraining)
                    {
                        m_AgentGroup2.SetGroupReward(-1f);
                        m_AgentGroup1.SetGroupReward(1f);
                    }

                    m_AgentGroup1.EndGroupEpisode();
                    m_AgentGroup2.EndGroupEpisode();
                    ResetScene();
                }

            }


        }


    }





    public void ResetScene()
    {

        deadInstances.Clear();
        foreach (ShootingAgent agent1 in Team1.AgentsList)
        {
            agent1.ResetAgent();
            // Add to team manager
            m_AgentGroup1.RegisterAgent(agent1);
        }
        foreach (ShootingAgent agent2 in Team2.AgentsList)
        {
            agent2.ResetAgent();
            // Add to team manager
            m_AgentGroup2.RegisterAgent(agent2);
        }




        //Reset counter
        m_ResetTimer = 0;


        Team1.m_NumberOfRemainingPlayers = NumAgents;
        Team2.m_NumberOfRemainingPlayers = NumAgents;

        isReady = true;
        mapGenerator.SwapwnObstacles();

    }



}
