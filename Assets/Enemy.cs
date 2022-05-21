using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.MLAgents;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int startinghealth = 100;

    private int currentHealth;
    private Vector3 startPosition;
    private NavMeshAgent navAgent;
    public EnemyManager enemyManager;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GetClosestAgent();
        enemyManager = transform.parent.parent.Find("EnemyManager").GetComponent<EnemyManager>();
        startPosition = transform.position;
        currentHealth = startinghealth;

        navAgent = GetComponent<NavMeshAgent>();
    }
    private GameObject GetClosestAgent()
    {
        Transform agentManager = transform.parent.parent.Find("Agents");
        bool isfind = false;
        int counter = 0;
        Transform closestAgent = null;
        while (!isfind && (counter < agentManager.childCount)) 
        {
            if (agentManager.GetChild(counter).gameObject.activeInHierarchy)
            {
                 closestAgent = agentManager.GetChild(counter);
                isfind = true;
            }
            else
            {
                counter += 1;
            }
        }
        if (counter == agentManager.childCount)
        {
            return null;
        }
        for (int i = 0; i < agentManager.childCount; i++)
        {
            if (agentManager.GetChild(i).gameObject.activeInHierarchy) {
                float actualDiastance = Vector3.Distance(closestAgent.gameObject.transform.position, transform.position);
                float newDistance = Vector3.Distance(agentManager.GetChild(i).gameObject.transform.position, transform.position);
                if (newDistance < actualDiastance)
                {
                    closestAgent = agentManager.GetChild(i);
                }
            }
            
        }
        return closestAgent.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!target.gameObject.activeInHierarchy)
        {
            target = GetClosestAgent();
        }
        
        transform.LookAt(target.transform.position);
        navAgent.SetDestination(target.transform.position);
    }

    public void GetShot(int damage, ShootingAgent shooter)
    {
        ApplyDamage(damage, shooter);
    }

    void ApplyDamage(int damage, ShootingAgent shooter)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die(shooter);
        }
    }

    

    void Die(ShootingAgent shooter)
    {
        gameObject.SetActive(false);
        Destroy(this.gameObject);
        enemyManager.RegisterDeath();
        
    }

  
    




}
