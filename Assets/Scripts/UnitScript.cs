using UnityEngine;

public class UnitScript : MonoBehaviour
{
    [SerializeField]
    private Unit unit;

    public int health;
    public int attackDamage;
    public float attackSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        health = unit.maxHealth.Value;
        attackDamage = unit.attackDamage.Value;
        attackSpeed = unit.attackSpeed.Value;
    }
    
}