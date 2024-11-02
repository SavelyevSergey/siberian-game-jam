using Core.Singleton;
using UnityEngine;

namespace Encounter.Impl
{
	public class EncounterStartService : MonoSingleton<EncounterStartService>, IEncounterStartService
	{
		public void StartEncounter(string encounter)
		{
			Debug.Log($"Start encounter [{encounter}]");
		}
	}
}
