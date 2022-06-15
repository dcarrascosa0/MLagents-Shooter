using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class ShootingAgent : Agent
{

    public int score = 0;
    public int damage = 100;
    public Transform shootingPoint;
    private int minStepsBetweenShots = 10;
    private bool shotAvailable = true;
    private int stepsUntilAvailable = 0;
    private Vector3 startPosition;
    private Rigidbody rb;
    public float velocidad = 0.4f;
    public float range = 2000f;
    public float turnVelocidad = 15f;
    public MeshRenderer floor;
    public Material winMaterial;
    public Material loseMaterial;
    public Enemy enemy;
    public EnemyManager enemyManager;
    public MapGenerator mapGenerator;
    public GameObject suelo;
    public TeamManager teamManager;
    public EnemySpawner enemySpawner;
    public Projectile projectile;
    public int shootForce;
    public Team Team;
    private bool isDead;
    public bool isTraining;
    public bool isEnemyPlayer;

    private void Shoot()
    {
        if (!shotAvailable)
        {
            return;
        }
        var direction = this.transform.right;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + direction.normalized, transform.right, out hit, 300))
        {
            if (((this.transform.tag == "mlagent1") && (hit.transform.tag == "mlagent2")) || ((this.transform.tag == "mlagent2") && (hit.transform.tag == "mlagent1")))
            {
                this.AddReward(0.001f);
                Projectile currentBullet = Instantiate<Projectile>(projectile, shootingPoint.position + direction.normalized, Quaternion.identity, this.transform.parent.parent.parent);
                if (this.gameObject.CompareTag("mlagent1"))
                {
                    currentBullet.tag = "projectile1";
                    currentBullet.SetTarget("mlagent2");
                }
                else
                {
                    currentBullet.tag = "projectile2";
                    currentBullet.SetTarget("mlagent1");
                }
                currentBullet.isEnemyPlayer = this.isEnemyPlayer;
                currentBullet.agent = this;
                currentBullet.agentObject = this.gameObject;
                currentBullet.SetDirection(new Vector3(direction.x, direction.y, direction.z));
                currentBullet.height = shootingPoint.transform.position.y;


                shotAvailable = false;
                stepsUntilAvailable = minStepsBetweenShots;
            }
            else
            {
                this.AddReward(-0.001f);
            }
        }
            

        
    }




    

    private void FixedUpdate()
    {
        /*float moveHorizontal = 0;
        float moveVertical =  0;
        Vector3 rotateDir = Vector3.zero;
        
        if (Input.GetKey(KeyCode.C))
        {
            rotateDir = transform.up * -1;
        }

        else if (Input.GetKey(KeyCode.V))
        {
            rotateDir = transform.up * 1;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 1 * velocidad;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVertical =  -1 * velocidad;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal =  1 * velocidad;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = -1 * velocidad;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            Shoot();
        }

        Vector3 dirToGo = new Vector3(moveVertical, 0f, moveHorizontal);


        transform.Rotate(rotateDir, Time.deltaTime * turnVelocidad);
        transform.position+=dirToGo * Time.deltaTime;
        */

        if (isTraining)
        {
            faceEnemy();
        }
           

       




    }

    private void faceEnemy()
    {
        RaycastHit hit;
        Debug.DrawRay(shootingPoint.transform.position, transform.right * 140, Color.green, 1f);
        if (Physics.Raycast(shootingPoint.transform.position, transform.right, out hit, 140))
        {

            if (this.transform.tag == "mlagent1")
            {
                if (hit.transform.tag == "mlagent2")
                {

                    this.AddReward(0.001f);
                }
            }
            if (this.transform.tag == "mlagent2")
            {
                if (hit.transform.tag == "mlagent1")
                {
                    this.AddReward(0.0001f);
                }
            }
        }

    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (!shotAvailable)
        {
            stepsUntilAvailable--;
            if (stepsUntilAvailable <= 0)
            {
                this.shotAvailable = true;
            }
        }
        if(isTraining)
            this.AddReward(-1f / MaxStep);


        if (isDead)
        {
            return;
        }

        if (actions.DiscreteActions[0] == 1)
        {
            this.Shoot();
        }

        var dirToGo = Vector3.zero;
        var rotateDir = Vector3.zero;
        var forwardAxis = actions.DiscreteActions[1];
        var rightAxis = actions.DiscreteActions[2];
        var rotateAxis = actions.DiscreteActions[3];

        switch (forwardAxis)
        {
            case 1:
                dirToGo = this.transform.forward * velocidad;
                break;
            case 2:
                dirToGo = this.transform.forward * -velocidad;
                break;
        }

        switch (rightAxis)
        {
            case 1:
                dirToGo = this.transform.right * velocidad;
                break;
            case 2:
                dirToGo = this.transform.right * -velocidad;
                break;
        }

        switch (rotateAxis)
        {
            case 1:
                rotateDir = new Vector3(0f, 1f, 0f) * -1f;
                break;
            case 2:
                rotateDir = new Vector3(0f, 1f, 0f) * 1f;
                break;
        }

        this.transform.Rotate(rotateDir * turnVelocidad * Time.deltaTime);
        rb.AddForce(dirToGo, ForceMode.VelocityChange);
        //transform.Translate(dirToGo * Time.deltaTime);



    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.shotAvailable);
        sensor.AddObservation(this.transform.right);
        sensor.AddObservation(this.isDead);


    }



    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;

        discreteActions[0] = Input.GetKey(KeyCode.P) ? 1 : 0;
        discreteActions[1] = 0;
        discreteActions[2] = 0;
        discreteActions[3] = 0;
        if (Input.GetKey(KeyCode.D))
        {
            discreteActions[1] = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            discreteActions[1] = 2;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            discreteActions[2] = 1;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            discreteActions[2] = 2;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            discreteActions[3] = 1;
        }

        else if (Input.GetKey(KeyCode.V))
        {
            discreteActions[3] = 2;
        }




    }

    public void Die()
    {
        isDead = true;
        if(isTraining)
            AddReward(-1f);
        this.gameObject.SetActive(false);
        if (!isEnemyPlayer)
        {
            teamManager.AgentKilled(this);
        }
        else
        {
            enemySpawner.AgentKilled(this);
        }




    }



    public override void Initialize()
    {
        teamManager = this.transform.parent.parent.parent.Find("TeamManager").GetComponent<TeamManager>();
        enemySpawner = this.transform.parent.parent.parent.Find("TeamManager").GetComponent<EnemySpawner>();

        if(!isEnemyPlayer)
        {
            isTraining = teamManager.isTraining;

        }
        else
        {
            isTraining = enemySpawner.isTraining;
        }
        suelo = this.transform.parent.parent.parent.Find("NavMesh").Find("Suelo").gameObject;
        rb = this.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        mapGenerator = this.transform.parent.parent.parent.Find("MapGenerator").GetComponent<MapGenerator>();
        isDead = false;

    }

    public void ResetAgent()
    {
        Vector3 newPos = RandomPosition();
        this.transform.position = new Vector3(newPos.x, 1.82f, newPos.z);
        rb.velocity = Vector3.zero;
        shotAvailable = true;
        if (this.Team.TeamId == 1)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        isDead = false;
        this.gameObject.SetActive(true);
    }

    Vector3 RandomPosition()
    {
        if (this.Team.TeamId == 1)
        {
            float xPos = -21f + suelo.transform.position.x;
            float zPos = Random.Range(-23f, 23f) + suelo.transform.position.z;
            return (new Vector3(xPos, 0, zPos));
        }
        else if (this.Team.TeamId == 2)
        {
            float xPos = 21f + suelo.transform.position.x;
            float zPos = Random.Range(-23f, 23f) + suelo.transform.position.z;
            return (new Vector3(xPos, 0, zPos));
        }
        else
        {
            return (new Vector3(0, 0, 0));
        }

    }



    private void OnCollisionEnter(Collision other)
    {

        if (other.transform.tag == "borders")
        {
            if(isTraining)
                this.AddReward(-0.01f);
        }
        if (other.transform.tag == "obstacles")
        {
            if(isTraining)
                this.AddReward(-0.01f);
        }


    }
}
