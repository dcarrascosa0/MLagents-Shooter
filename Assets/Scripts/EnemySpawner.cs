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
    public bool isTraining;
    public bool isEnemyPlayer;
    private List<int> deadIds;

    private ScoreManager scoreManager;


    void Start()
    {
        scoreManager = transform.parent.parent.Find("ScoreManager").GetComponent<ScoreManager>();
        deadIds = new List<int>();
        Team = transform.parent.Find("Teams").Find("Team1").GetComponent<Team>();
        Team.TeamId = 1;

        for (int i = 0; i < NumAgents; i++)
        {
            ShootingAgent myAgentTeam = Instantiate<ShootingAgent>(Agent_Team1, new Vector3(0, 0, 0), Quaternion.identity, Team.transform);
            myAgentTeam.Team = Team;
            myAgentTeam.isTraining = this.isTraining;
            myAgentTeam.isEnemyPlayer = this.isEnemyPlayer;
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
        if (isTraining)
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
        
    }

    public void AgentKilled(ShootingAgent agent)
    {
        if (!deadIds.Contains(agent.GetInstanceID()))
        {
            deadIds.Add(agent.GetInstanceID());
            
            Team.m_NumberOfRemainingPlayers -= 1;
            if (Team.m_NumberOfRemainingPlayers <= 0)
            {
                scoreManager.UpdateScoreTeam2();
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
        playerController.deaths.Clear();

        foreach (ShootingAgent agent1 in Team.AgentsList)
        {
            agent1.ResetAgent();
            // Add to team manager
            m_AgentGroup1.RegisterAgent(agent1);
        }
        Transform teams = transform.parent;

        for (int i = 0; i < teams.childCount; i++)
        {
            if ((teams.GetChild(i).transform.tag == "projectile1") || (teams.GetChild(i).transform.tag == "projectile2"))
            {
                Destroy(teams.GetChild(i).gameObject);
            }
        }

        //Reset counter
        m_ResetTimer = 0;

        deadIds.Clear();

        Team.m_NumberOfRemainingPlayers = NumAgents;

        mapGenerator.SwapwnObstacles();

    }



}
