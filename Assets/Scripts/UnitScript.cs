using UnityEngine;

public class UnitScript : MonoBehaviour
{
    [SerializeField]
    public Unit unit;

    public float health;
    public float attackDamage;
    public float attackSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if (unit)
        {
            health = unit.maxHealth.Value;
            attackDamage = unit.attackDamage.Value;
            attackSpeed = unit.attackSpeed.Value;
        }
    }
    
}