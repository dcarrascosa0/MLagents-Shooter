using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    
    public ShootingAgent agent;
    public int EnemyCount;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject Enemy;
    public GameObject parentEnemies;
    private int deaths;
    public GameObject suelo;
    public Material winMaterial;
    public MeshRenderer floor;
    public MapGenerator mapGenerator;
    private AgentManager agentManager;
    void Start()
    {
        agentManager = transform.parent.Find("AgentManager").GetComponent<AgentManager>();
        mapGenerator = transform.parent.Find("MapGenerator").GetComponent<MapGenerator>();
        deaths = 0;
        
        
        
        
    }
    public void ResetEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies.Clear();
        RespawnEnemies();
    }

    public void AddNewEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
        
    }

    private void OnEnemyDeath(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    public bool isEveryEnemyDead()
    {     
       
        return deaths>=enemies.Count;
    }

    public void RegisterDeath()
    {
        deaths++;
        if (isEveryEnemyDead())
        {
            floor.material = winMaterial;       
            
            agentManager.ResetScene();
            agentManager.m_AgentGroup.AddGroupReward(1f);
            

        }
    }

    public void ResetEpidode()
    {
        mapGenerator.SwapwnObstacles();
        ResetEnemies();

    }

    

    public void RespawnEnemies()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            float xPos = 23f + suelo.transform.position.x;
            float zPos = Random.Range(-23f, 23f) + suelo.transform.position.z;
            
            GameObject myEnemy = Instantiate(Enemy) as GameObject;
            myEnemy.GetComponent<NavMeshAgent>().Warp(new Vector3(xPos, 0, zPos));
            myEnemy.transform.rotation = Quaternion.identity;
            myEnemy.transform.SetParent(parentEnemies.transform);

            AddNewEnemy(myEnemy);
            myEnemy.SetActive(true);
        }

        deaths = 0;
        
    }
    void Update()
    {
        
    }
}
