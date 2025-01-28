using ScriptableObjectArchitecture;
using UnityEngine;


    [CreateAssetMenu(fileName = "Unit", menuName = "Custom/Unit")]
    public class Unit : ScriptableObject
    {
        public FloatReference maxHealth;
        public FloatReference attackDamage;
        public FloatReference attackSpeed;
    }

