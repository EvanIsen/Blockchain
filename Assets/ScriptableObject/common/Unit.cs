using ScriptableObjectArchitecture;
using UnityEngine;


    [CreateAssetMenu(fileName = "Unit", menuName = "Custom/Unit")]
    public class Unit : ScriptableObject
    {
        public IntReference maxHealth;
        public IntReference attackDamage;
        public FloatReference attackSpeed;
    }

