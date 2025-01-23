using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class UnitEvent : UnityEvent<Unit> { }

	[CreateAssetMenu(
	    fileName = "UnitVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Unit",
	    order = 120)]
	public class UnitVariable : BaseVariable<Unit, UnitEvent>
	{
	}
}