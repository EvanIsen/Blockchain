using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public enum Side
{
    DarkSide,
    LightSide
};
public class IaMovement : MonoBehaviour
{ 
    [FormerlySerializedAs("targetSide")] [FormerlySerializedAs("_side")] [SerializeField]
    private Side side;
    private NavMeshAgent _agent;
    [SerializeField]
    private Material _material;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        Material[] copyMaterials;
        SkinnedMeshRenderer childObject = GetComponentInChildren<SkinnedMeshRenderer>();
        if (side == Side.DarkSide)
        {
            copyMaterials = childObject.materials;
            copyMaterials[2] = _material;
            childObject.materials = copyMaterials;
        }
        _agent = GetComponent<NavMeshAgent>();
        Vector3 darkTower = GameObject.FindGameObjectWithTag("Enemy_Tower").transform.position;
        Vector3 lightTower = GameObject.FindGameObjectWithTag("Ally_Tower").transform.position;
        if(side == Side.LightSide)
            _agent.SetDestination(darkTower);
        else 
            _agent.SetDestination(lightTower);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(tag))
        {
            _agent.SetDestination(other.transform.position);
            _agent.stoppingDistance = 2f;
            Debug.Log(name + " has entered and " + _agent.remainingDistance);
            Debug.Log("J'attaque woula");
            
        }
    }
}
