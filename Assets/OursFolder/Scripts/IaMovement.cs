using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
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
    private Thread _thread;
    

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
        // StartCoroutine(_attackCoroutine);

        _thread = new Thread(() => Attack(_unit.attackSpeed));
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
        // _attackCoroutine = Attack(_unit.attackSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(tag))
        {
            if(_targetMonster == null)
                _targetMonster = other.gameObject.GetComponent<UnitScript>();
            _agent.SetDestination(_targetMonster.transform.position);
            // _agent.stoppingDistance = 1.5f;
           _thread.Start();
            _agent.ResetPath();
        }
    }



    private async void Attack(float cooldown)
    {
        try
        {
            bool targetStillAlive = true;
            while (targetStillAlive)
            {
                await Task.Delay((int)cooldown * 1000);
                Debug.Log("is Working");
                if (_targetMonster != null && _unit != null)
                {
                    Debug.Log(name + " is attacking");
                    _targetMonster.health -= _unit.attackDamage;
                    Debug.Log(name + " hp : " + _unit.health);
                }

                

                if (_targetMonster.health <= 0)
                {
                    Debug.Log("End");
                    targetStillAlive = false;
                }

                if (_unit.health <= 0)
                {
                    Destroy(gameObject);
                }
            }
            Debug.Log(name + " Win the fight");
            GetTargetTower();
            await Task.Yield();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
}
