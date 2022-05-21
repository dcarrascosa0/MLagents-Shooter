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
    public GameObject projectile;
    public Transform shootingPoint;
    private Rigidbody rb;
    public bool canMove = true;
    public Vector3 startingPosition;
    public EnemySpawner enemySpawner;




    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        rb = transform.GetComponent<Rigidbody>();
        enemySpawner = transform.parent.Find("TeamManager").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 rotateDir = Vector3.zero;
        float dirToGoX = 0;
        float dirToGoZ = 0;

        bool moving = false;
        bool rotating = false;

        if (Input.GetKey(KeyCode.D))
        {
            dirToGoZ = -velocidad;
            Move(dirToGoX, dirToGoZ);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            dirToGoZ = velocidad;
            Move(dirToGoX, dirToGoZ);

        }
        else if (Input.GetKey(KeyCode.W))
        {
            dirToGoX = velocidad;
            Move(dirToGoX, dirToGoZ);

        }

        else if (Input.GetKey(KeyCode.S))
        {
            dirToGoX = -velocidad;
            Move(dirToGoX, dirToGoZ);

        }
        else if (Input.GetKey(KeyCode.C))
        {
            rotateDir = this.transform.up * -1f;
            Rotate(rotateDir);

        }

        else if (Input.GetKey(KeyCode.V))
        {
            rotateDir = this.transform.up * 1f;
            Rotate(rotateDir);

        }
        else if (Input.GetKey(KeyCode.J))
        {
            Shoot();
        }





        if (!shotAvailable)
        {
            stepsUntilAvailable--;
            if (stepsUntilAvailable <= 0)
            {
                this.shotAvailable = true;
            }
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
        if (!shotAvailable)
        {
            return;
        }

        var direction = this.shootingPoint.transform.right;

        Quaternion currentRotation = transform.rotation;
        Vector3 currentPosition = transform.position;


        GameObject currentBullet = Instantiate(projectile, shootingPoint.position, Quaternion.identity, this.transform.parent);


        //currentBullet.GetComponent<Projectile>().agent = this.gameObject;

        currentBullet.tag = "projectile2";
        currentBullet.GetComponent<Projectile>().SetTarget("mlagent1");
        currentBullet.GetComponent<Projectile>().height = shootingPoint.transform.position.y;




        currentBullet.GetComponent<Projectile>().SetDirection(new Vector3(direction.x, direction.y, direction.z));

        transform.rotation = currentRotation;
        transform.position = currentPosition;
        shotAvailable = false;
        stepsUntilAvailable = minStepsBetweenShots;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "projectile1")
        {
            if (collision.transform.GetComponent<Projectile>().agent.tag != transform.tag)
            {
                transform.position = startingPosition;
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));

                enemySpawner.ResetScene();
            }

        }
    }
}