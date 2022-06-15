using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody _rb = null;
    public float speed = 10;
    private Collider[] colliders;

    [SerializeField] private Transform _target;
    [SerializeField] private GameObject obstacles;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        transform.localPosition += new Vector3(moveHorizontal, 0, moveVertical) * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Wall>(out Wall wall))
        {
            
            _target.transform.localPosition = new Vector3(Random.Range(-22f, 24f), -0.27f, Random.Range(-18f, 26f));
            transform.localPosition = new Vector3(Random.Range(-22f, 24f), -0.27f, Random.Range(-18f, 26f));
            MoveObstacles();


        }

        else
        {
            if (other.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacle))
            {
                
                _target.transform.localPosition = new Vector3(Random.Range(-22f, 24f), -0.27f, Random.Range(-18f, 26f));
                transform.localPosition = new Vector3(Random.Range(-22f, 24f), -0.27f, Random.Range(-18f, 26f));
                MoveObstacles();

            }
        }
    }

    private void MoveObstacles()
    {
        for (int i = 0; i < obstacles.transform.childCount; i++)
        {
            Transform Children = obstacles.transform.GetChild(i);
            int iterations = 0;
            Vector3 candidate_position = new Vector3(Random.Range(-22f, 24f), -0.27f, Random.Range(-18f, 26f));
            colliders = Physics.OverlapSphere(candidate_position, Children.transform.localScale.x / 2);
            bool is_colliding = CheckColliders(colliders);
            while (is_colliding==false || iterations<100)
            {
                iterations++;
                candidate_position = new Vector3(Random.Range(-22f, 24f), -0.27f, Random.Range(-18f, 26f));
                colliders = Physics.OverlapSphere(candidate_position, Children.transform.localScale.x / 2);
                is_colliding = CheckColliders(colliders);
            }
            Children.transform.localPosition = candidate_position;

        }
    }

    private bool CheckColliders(Collider[] collider_list)
    {
        bool result = true;
        for(int i = 0; i < collider_list.Length; i++)
        {
            Collider collider = (Collider)collider_list.GetValue(i);
            if (collider.tag == "obstacles" || collider.tag == "target" || collider.tag == "borders")
            {
                result = false;
            }
        }

        return (result);
    }
}
