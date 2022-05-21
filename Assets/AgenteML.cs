using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class AgenteML : Agent
{
    [SerializeField] private float _fuerzaMovimient = 100;
    [SerializeField] private Transform _target;
    [SerializeField] private Material winmaterial;
    [SerializeField] private Material losematerial;
    [SerializeField] private MeshRenderer floorMeshRender;


    public bool _training = true;

    private Rigidbody _rb;

    public override void Initialize()
    {
        _rb = GetComponent<Rigidbody>();
        if (!_training) MaxStep = 0;
    }

    public override void OnEpisodeBegin()
    {
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Vector3 movimiento = new Vector3(actions.ContinuousActions[0], 0f, actions.ContinuousActions[1]);
        _rb.AddForce(movimiento * _fuerzaMovimient * Time.deltaTime);
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        Vector3 distancia = transform.localPosition - _target.transform.localPosition;
        sensor.AddObservation(distancia.normalized);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movment = new Vector3(moveHorizontal, 0f, moveVertical);
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = movment.x;
        continuousActionsOut[1] = movment.z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Goal>(out Goal goal))
        {
            AddReward(1.0f);
            floorMeshRender.material = winmaterial;
            _target.transform.localPosition = new Vector3(Random.Range(-2.6f, 6.0f), -0.27f, Random.Range(-0.3f, 7.8f));
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Wall>(out Wall wall))
        {
            AddReward(-0.1f);

            floorMeshRender.material = losematerial;
        }
    }
}
