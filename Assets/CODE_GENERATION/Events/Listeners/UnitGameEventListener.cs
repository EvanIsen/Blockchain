using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Unit")]
	public sealed class UnitGameEventListener : BaseGameEventListener<Unit, UnitGameEvent, UnitUnityEvent>
	{
	}
}