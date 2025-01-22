using UnityEngine;

public class MaokaiUnit : MonoBehaviour
{
    [SerializeField]
    private Unit unit;

    private int _health;
    private int _attackDamage;
    private float _attackSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        _health = unit.maxHealth.Value;
        _attackDamage = unit.attackDamage.Value;
        _attackSpeed = unit.attackSpeed.Value;
    }
    
}
