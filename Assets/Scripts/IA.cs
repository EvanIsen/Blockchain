using System;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public enum Side
{
    DarkSide,
    LightSide
}

public class IA : MonoBehaviour
{
    [SerializeField]
    public Side side;
    
    private NavMeshAgent _agent;
    [SerializeField] 
    private UnitScript  ennemy;
    private UnitScript _unit;
    private UnitScript _darkTower_unit;
    private UnitScript _lightTower_unit;
    private GameObject _darkTower;
    private GameObject _lightTower; 
    private Vector3 _darkTowerPos;
    private Vector3 _lightTowerPos;
    [SerializeField]
    private Material _material;
    private Animator _animator;
    private Animator _ennemyAnimator;
    
    public UnityEvent _final_ath;
    void Start()
    {
        _final_ath = new UnityEvent();
        _agent = GetComponent<NavMeshAgent>();
        _lightTower = GameObject.Find("Tower");
        _darkTower = GameObject.Find("Tower (1)");
        _darkTowerPos = _darkTower.transform.position;
        _lightTowerPos = _lightTower.transform.position;
        _darkTower_unit= _darkTower.GetComponent<UnitScript>();
        _lightTower_unit = _lightTower.GetComponent<UnitScript>();
        GetAttackSpeed();
        AffectMaterial();
       _animator = GetComponent<Animator>();
       Invoke("GetTargetTower",2);
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
                _agent.SetDestination(new Vector3(Random.Range(_darkTowerPos.x, _darkTowerPos.x + 1.5f) ,0.0f , 
                Random.Range(_darkTowerPos.z-1.5f, _darkTowerPos.z + 1)));
            else _agent.SetDestination(new Vector3(Random.Range(_darkTowerPos.x-1.5f, _darkTowerPos.x) ,0.0f , 
                Random.Range(_darkTowerPos.z-1.5f, _darkTowerPos.z + 1)));
            _agent.stoppingDistance = 0;
        }
        else
        {
            if(_agent.transform.position.x > 0)
                _agent.SetDestination(new Vector3(Random.Range(_lightTowerPos.x, _lightTowerPos.x + 1.5f) ,0.0f , 
                Random.Range(_lightTowerPos.z, _lightTowerPos.z + 1)));
            else _agent.SetDestination(new Vector3(Random.Range(_lightTowerPos.x-1.5f, _lightTowerPos.x) ,0.0f , 
                Random.Range(_lightTowerPos.z - 1.5f, _lightTower.transform.position.z + 1 )));
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

    private void Update()
    {
        if (_agent.isStopped || _agent.remainingDistance < 0.5f)
            _animator.SetFloat("Speed",0);
        else _animator.SetFloat("Speed",1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(tag) && other.GetComponent<UnitScript>() && !ennemy)
        {
            _ennemyAnimator = other.gameObject.GetComponent<Animator>();
           StartCoroutine(Attack(_unit.attackSpeed, other.gameObject));
        }
    }

    private IEnumerator Attack(float cooldown, GameObject target)
    {
        if (!ennemy)
        {
            ennemy = target.GetComponent<UnitScript>();
            _agent.SetDestination(transform.position);
            _agent.stoppingDistance =5f;
            transform.LookAt(target.transform.position);
        }

        int attackCount= 1 ;
        while (ennemy.health > 0)
        {
            _agent.isStopped = true;
            _animator.SetBool("isAttacking",true);
            _animator.SetInteger("AttackCount",attackCount);
            attackCount++;
            if (attackCount == 4) attackCount = 1;
            ennemy.health -= _unit.attackDamage;
            yield return new WaitForSeconds(cooldown);
        }
        _animator.SetBool("isAttacking",false);
        if(_ennemyAnimator)
            _ennemyAnimator.SetBool("isDead",true);
        Invoke("KillEnnemy",2);
        if (_unit.health > 0)
        {
            attackCount = 1;
            _agent.isStopped = false;
            GetTargetTower();
        }
    }

    private void KillEnnemy()
    {
        if (ennemy)
        {
            Destroy(ennemy.gameObject);
            ennemy = null;
        }
    }
}
