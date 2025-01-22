using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "UnitGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Unit",
	    order = 120)]
	public sealed class UnitGameEvent : GameEventBase<Unit>
	{
	}
}