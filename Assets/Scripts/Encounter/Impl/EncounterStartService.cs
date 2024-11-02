using System;
using Core.Singleton;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Encounter.Impl
{
	public class EncounterStartService : MonoSingleton<EncounterStartService>, IEncounterStartService
	{
		private EncounterList _encounterList;
		private EncounterController _encounterController;
		
		private void Awake()
		{
			_encounterList = Resources.Load<EncounterList>("Encounter List");
			_encounterController = FindFirstObjectByType<EncounterController>();
		}

		[Button]
		public void StartEncounter(string encounter)
		{
			var model = _encounterList.Get(encounter);
			
			Debug.Log($"Started encounter {encounter}!");
			_encounterController.SetupEncounter(model);
			//get encounter model
			//init encounter singleton with model
		}
	}
}
