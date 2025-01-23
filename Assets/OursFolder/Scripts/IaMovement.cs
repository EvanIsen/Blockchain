using System;
using System.Collections;
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
   
    [SerializeField]
    private Side side;
    private NavMeshAgent _agent;
    [SerializeField]
    private Material _material;

    public UnitScript _targetMonster = null;
    private Vector3 darkTower;
    private Vector3 lightTower;
    
   
    private UnitScript _unit = null;
    private IEnumerator _attackCoroutine ;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        //change materials for the ennemy 
        Material[] copyMaterials;
        SkinnedMeshRenderer childObject = GetComponentInChildren<SkinnedMeshRenderer>();
        if (side == Side.DarkSide)
        {
            copyMaterials = childObject.materials;
            copyMaterials[2] = _material;
            childObject.materials = copyMaterials;
        }
        
        //get objectif position
        _agent = GetComponent<NavMeshAgent>();
        lightTower = GameObject.FindGameObjectWithTag("Ally_Tower").transform.position;
        darkTower = GameObject.FindGameObjectWithTag("Enemy_Tower").transform.position;
        GetTargetTower();
        GetAttackSpeed();

    }

    private void GetTargetTower()
    {
        if(side == Side.LightSide)
            _agent.SetDestination(darkTower);
        else 
            _agent.SetDestination(lightTower);
    }
    private void GetAttackSpeed()
    {
        _unit = GetComponent<UnitScript>();
        _attackCoroutine = Attack(_unit.attackSpeed);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag(tag))
        {
            if(_targetMonster == null)
                _targetMonster = other.gameObject.GetComponent<UnitScript>();
            _agent.SetDestination(_targetMonster.transform.position);
            _agent.stoppingDistance = 1.5f;
            StartCoroutine(_attackCoroutine);
            
            //launch attack
            //play animation
        }
    }

    private IEnumerator Attack(float cooldown)
    {
        
        if (_targetMonster != null && _unit != null)
        {
            Debug.Log(name + " is attacking");
            _targetMonster.health -= _unit.attackDamage;
            Debug.Log(name + " hp : " + _unit.health);
        }

        if (_targetMonster.health > 0)
        {
            yield return new WaitForSeconds(cooldown);
            Debug.Log("Start coroutine again");
            StartCoroutine(_attackCoroutine);
        }
        else GetTargetTower();
       
        
    } 
   
}
