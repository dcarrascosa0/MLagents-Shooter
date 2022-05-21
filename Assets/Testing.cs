using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidad;
    public float turnVelocidad;
    public Transform shootingPoint;
    public GameObject projectile;
    void Start()
    {
        
    }

    private void Shoot()
    {
        
        var direction = this.transform.right;


        GameObject currentBullet = Instantiate(projectile, shootingPoint.position, Quaternion.identity, this.transform);
        if (this.gameObject.CompareTag("mlagent1"))
        {
            currentBullet.GetComponent<Projectile>().target = "mlagent2";
        }
        else
        {
            currentBullet.GetComponent<Projectile>().target = "mlagent1";
        }
        currentBullet.GetComponent<Projectile>().SetDirection(new Vector3(direction.x, direction.y, direction.z));

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = 0;
        float moveVertical = 0;
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
            moveVertical = -1 * velocidad;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = 1 * velocidad;
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
        this.gameObject.transform.position += dirToGo * Time.deltaTime;

    }
}
