using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public enum TargetSide
{
    DarkSide,
    LightSide
};
public class IaMovement : MonoBehaviour
{ 
    [FormerlySerializedAs("_side")] [SerializeField]
    private TargetSide targetSide;
    private NavMeshAgent _agent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Vector3 darkTower = GameObject.FindGameObjectWithTag("Enemy_Tower").transform.position;
        Vector3 lightTower = GameObject.FindGameObjectWithTag("Ally_Tower").transform.position;
        if(targetSide == TargetSide.DarkSide)
            _agent.SetDestination(darkTower);
        else 
            _agent.SetDestination(lightTower);
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag(tag))
         _agent.SetDestination(other.transform.position);
    }
}
