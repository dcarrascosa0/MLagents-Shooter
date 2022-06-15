using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody Rigidbody;
    private Vector3 Direction;
    public ShootingAgent agent;
    public GameObject agentObject;
    public int shootForce;
    private bool isDirected = false;
    public Vector3 direct;
    public string target;
    public int id;
    private MeshRenderer projColor;
    public Material team1Color;
    public Material team2Color;
    public float height;
    public bool isTraining;
    public int numAgents;
    public TeamManager teamManager;
    public EnemySpawner enemySpawner;
    public bool isEnemyPlayer;
    void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

    public void SetDirection(Vector3 direction)
    {
        direct = new Vector3(direction.x, height, direction.z);
        isDirected = true;


    }
    public void SetTarget(string target)
    {
        projColor = this.GetComponent<MeshRenderer>();
        this.target = target;
        if (target == "mlagent1")
        {
            projColor.material = team2Color;
        }
        if (target == "mlagent2")
        {
            projColor.material = team1Color;
        }


    }

    void Start()
    {
        teamManager = this.transform.parent.Find("TeamManager").GetComponent<TeamManager>();
        enemySpawner = this.transform.parent.Find("TeamManager").GetComponent<EnemySpawner>();
       
        if(!isEnemyPlayer)
        {
            try
            {
                isTraining = enemySpawner.isTraining;

            }
            catch { }
        }
        else
        {
            isTraining = teamManager.isTraining;
        }
        Rigidbody = this.GetComponent<Rigidbody>();
        Destroy(this.gameObject, 8f);
    }

    private void FixedUpdate()
    {
        if (isDirected)
        {
            transform.Translate(direct * shootForce * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        try
        {
            if (other.gameObject.tag == agent.transform.tag)
            {
                Physics.IgnoreCollision(other.transform.GetComponent<Collider>(), transform.GetComponent<Collider>());

            }
        }
        catch { }
        
        if (other.gameObject.tag == "projectile1" || other.gameObject.tag == "projectile2")
        {
            Physics.IgnoreCollision(other.transform.GetComponent<Collider>(), transform.GetComponent<Collider>());

        }

        else if (other.gameObject.tag == "borders")
        {
            Destroy(this.gameObject);
            /*if (agent.tag == "mlagent1")
            {
                agent.GetComponent<ShootingAgent>().AddReward(-0.005f);
            }
            */

            if(isTraining)
                agent.AddReward(-0.005f);

        }
        else if (other.gameObject.tag == "obstacles")
        {
            Destroy(this.gameObject);
            /*if (agent.tag == "mlagent1")
            {
                agent.GetComponent<ShootingAgent>().AddReward(-0.005f);
            }
            */

            if(isTraining)
                agent.AddReward(-0.005f);
        }
        else if (other.gameObject.tag == "suelo")
        {
            Destroy(this.gameObject);

            /*if (agent.tag == "mlagent1")
            {
                agent.GetComponent<ShootingAgent>().AddReward(-0.005f);
            }
            */

            if(isTraining)
                agent.AddReward(-0.005f);
        }
        else if (other.gameObject.tag != this.target)
        {
            Destroy(this.gameObject);
            /*if (agent.tag == "mlagent1")
            {
                agent.GetComponent<ShootingAgent>().AddReward(-0.005f);
            }
            */

            if(isTraining)
                agent.AddReward(-0.005f);
        }
        else if (other.gameObject.tag == this.target)
        {
            Destroy(this.gameObject);
            if(isTraining)
                agent.AddReward(1.0f / numAgents);

            if (!isEnemyPlayer)
            {
                other.gameObject.GetComponent<ShootingAgent>().Die();

            }
            else
            {
                if (other.gameObject.tag == "mlagent1" && isEnemyPlayer)
                    other.gameObject.GetComponent<ShootingAgent>().Die();
            }




            /*if (agent.tag == "mlagent2")
            {
                other.gameObject.GetComponent<ShootingAgent>().Die();
            }
            */




        }
    }
}
