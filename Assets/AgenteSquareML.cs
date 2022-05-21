using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System.Linq;

public class AgenteSquareML : Agent
{
    [SerializeField] private float velocidad = 30f;
    [SerializeField] private Transform _target;
    [SerializeField] private Material winmaterial;
    [SerializeField] private Material losematerial;
    [SerializeField] private MeshRenderer floorMeshRender;


    public bool _training = true;
    public GameObject obstacles;

    private Rigidbody _rb;

    public Collider[] colliders;
    public override void Initialize()
    {
        _rb = GetComponent<Rigidbody>();
        if (!_training) MaxStep = 0;
    }

    public override void OnEpisodeBegin()
    {
        _target.transform.localPosition = new Vector3(Random.Range(-22f, 24f), -0.27f, Random.Range(-18f, 26f));
        transform.localPosition = new Vector3(Random.Range(-22f, 24f), -0.27f, Random.Range(-18f, 26f));

    }
    

    public override void OnActionReceived(ActionBuffers actions)
    {
        float movimientoX = actions.ContinuousActions[0];
        float movimientoZ = actions.ContinuousActions[1];


        transform.localPosition += new Vector3(movimientoX, 0, movimientoZ) * Time.deltaTime * velocidad;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        Vector3 distancia = transform.localPosition - _target.transform.localPosition;
        sensor.AddObservation(distancia.normalized);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {  
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Goal>(out Goal goal))
        {
            AddReward(1.0f);
            floorMeshRender.material = winmaterial;
            _target.transform.localPosition = new Vector3(Random.Range(-22f, 24f), -0.27f, Random.Range(-18f, 26f));
            transform.localPosition = new Vector3(Random.Range(-22f, 24f), -0.27f, Random.Range(-18f, 26f));
            MoveObstacles();

        }


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Wall>(out Wall wall))
        {
            AddReward(-0.1f);
            floorMeshRender.material = losematerial;
            _target.transform.localPosition = new Vector3(Random.Range(-22f, 24f), -0.27f, Random.Range(-18f, 26f));
            transform.localPosition = new Vector3(Random.Range(-22f, 24f), -0.27f, Random.Range(-18f, 26f));
            MoveObstacles();


        }

        else
        {
            if (other.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacle))
            {
                AddReward(-0.1f);
                floorMeshRender.material = losematerial;
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
            while (is_colliding == false || iterations < 100)
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
        for (int i = 0; i < collider_list.Length; i++)
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

