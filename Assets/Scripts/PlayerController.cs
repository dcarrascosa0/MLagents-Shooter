using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int velocidad;
    public int turnVelocidad;
    private bool shotAvailable = true;
    private int stepsUntilAvailable = 0;
    private int minStepsBetweenShots = 20;
    public Projectile projectile;
    public Transform shootingPoint;
    private Rigidbody rb;
    public bool canMove = true;
    public Vector3 startingPosition;
    public EnemySpawner enemySpawner;
    public bool isEnemyPlayer;
    float angle;
    bool canShoot;
    private ScoreManager scoreManager;
    public List<int> deaths;
    float lastUpdate;



    // Start is called before the first frame update
    void Start()
    {
        deaths = new List<int>();
        scoreManager = transform.parent.parent.Find("ScoreManager").GetComponent<ScoreManager>();
        canShoot = true;
        Cursor.lockState = CursorLockMode.Locked;
        startingPosition = transform.position;
        rb = transform.GetComponent<Rigidbody>();
        enemySpawner = transform.parent.Find("TeamManager").GetComponent<EnemySpawner>();
        isEnemyPlayer = enemySpawner.isEnemyPlayer;
        transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        angle = 180.0f;

    }

    private void Update()
    {

        angle += Input.GetAxis("Mouse X") * turnVelocidad;
        transform.localRotation = Quaternion.Euler(0, angle, 0);
        if (Input.GetMouseButtonDown(0))
        {
            
            Shoot();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lastUpdate += Time.deltaTime;
        Vector3 rotateDir = Vector3.zero;
        float dirToGoX = 0;
        float dirToGoZ = 0;

        bool moving = false;
        bool rotating = false;

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dirToGoZ = -velocidad;
            Move(0, dirToGoZ);
        }
        if (Input.GetKey(KeyCode.A))
        {
            dirToGoZ = velocidad;
            Move(0, dirToGoZ);

        }
        if (Input.GetKey(KeyCode.W))
        {
            dirToGoX = velocidad;
            Move(dirToGoX, 0);

        }

        if (Input.GetKey(KeyCode.S))
        {
            dirToGoX = -velocidad;
            Move(dirToGoX, 0);

        }
        


        





        



    }

    private void Move(float x, float z)
    {
        transform.Translate(new Vector3(x, 0f, z) * Time.deltaTime);



    }

    private void Rotate(Vector3 rotateDir)
    {
        transform.Rotate(rotateDir * turnVelocidad * Time.deltaTime);

    }

    private void Shoot()
    {
       

        var direction = this.shootingPoint.transform.right;

        


        Projectile currentBullet = Instantiate<Projectile>(projectile, shootingPoint.position + direction.normalized, Quaternion.identity, this.transform.parent);


        currentBullet.agentObject = this.gameObject;
        currentBullet.isEnemyPlayer = isEnemyPlayer;
        currentBullet.tag = "projectile2";
        currentBullet.SetTarget("mlagent1");
        currentBullet.height = shootingPoint.transform.position.y;




        currentBullet.SetDirection(new Vector3(direction.x, direction.y, direction.z));

       

    }

    private void AgentDeath()
    {
        if (lastUpdate > 1.0f)
        {
            deaths.Add(this.GetInstanceID());
            enemySpawner.m_AgentGroup1.EndGroupEpisode();
            enemySpawner.ResetScene();
            scoreManager.UpdateScoreTeam1();
            lastUpdate = 0.0f;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "projectile1")
        {
            if (collision.transform.GetComponent<Projectile>().agent.tag != transform.tag)
            {
                if(!deaths.Contains(this.GetInstanceID()))
                {
                    AgentDeath();
                }

            }

        }
    }
}