using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class UnitReference : BaseReference<Unit, UnitVariable>
	{
	    public UnitReference() : base() { }
	    public UnitReference(Unit value) : base(value) { }
	}
}