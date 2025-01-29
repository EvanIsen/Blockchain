using System;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using Random = UnityEngine.Random;


public class IA : MonoBehaviour
{
    [SerializeField]
    private Side side;
    
    private NavMeshAgent _agent;
    [SerializeField] 
    private UnitScript  ennemy;
    private UnitScript _unit;
    private Vector3 darkTower;
    private Vector3 lightTower;
    [SerializeField]
    private Material _material;
    
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        lightTower = GameObject.FindGameObjectWithTag("Ally_Tower").transform.position;
        darkTower = GameObject.FindGameObjectWithTag("Enemy_Tower").transform.position;
        GetTargetTower();
        GetAttackSpeed();
        AffectMaterial();
       
    }
    private void GetAttackSpeed()
    {
        _unit = GetComponent<UnitScript>();
    }
    private void GetTargetTower()
    {
        if (side == Side.LightSide)
        {
            if(_agent.transform.position.x > 0) 
                _agent.SetDestination(new Vector3(Random.Range(darkTower.x, darkTower.x + 1.5f) ,0.0f , 
                Random.Range(darkTower.z-1.5f, darkTower.z + 1)));
            else _agent.SetDestination(new Vector3(Random.Range(darkTower.x-1.5f, darkTower.x) ,0.0f , 
                Random.Range(darkTower.z-1.5f, darkTower.z + 1)));
            _agent.stoppingDistance = 0;
        }
        else
        {
            if(_agent.transform.position.x > 0)
                _agent.SetDestination(new Vector3(Random.Range(lightTower.x, lightTower.x + 1.5f) ,0.0f , 
                Random.Range(lightTower.z, lightTower.z + 1)));
            else _agent.SetDestination(new Vector3(Random.Range(lightTower.x-1.5f, lightTower.x) ,0.0f , 
                Random.Range(lightTower.z - 1.5f, lightTower.z + 1 )));
            _agent.stoppingDistance = 0;
        }
            
    }

    private void AffectMaterial()
    {
        int value;
        if (_unit.unit.name == "SO_Maokai")
            value = 2;
        else value = 1;
        Material[] copyMaterials;
        SkinnedMeshRenderer childObject = GetComponentInChildren<SkinnedMeshRenderer>();
        if (side == Side.DarkSide)
        {
            tag = "DarkMonster";
            copyMaterials = childObject.materials;
            copyMaterials[value] = _material;
            childObject.materials = copyMaterials;
        }
        else tag = "LightMonster";
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(tag) && other.GetComponent<UnitScript>())
        {
           StartCoroutine(Attack(_unit.attackSpeed, other.gameObject));
        }
    }

    private IEnumerator Attack(float cooldown, GameObject target)
    {
        if (!ennemy)
        {
            ennemy = target.GetComponent<UnitScript>();
            _agent.SetDestination(transform.position);
            _agent.stoppingDistance =10f;
            Debug.Log(ennemy);
        }

        while (ennemy.health > 0)
        {
            ennemy.health -= _unit.attackDamage;
            yield return new WaitForSeconds(cooldown);
            Debug.Log(ennemy.health);
        }
        Destroy(target.gameObject);
        ennemy = null;
        GetTargetTower();
        
        
    }
}
