using Core.Singleton;
using UnityEngine;

namespace Encounter.Impl
{
	public class EncounterResultHandler : SimpleSingleton<EncounterResultHandler>, IEncounterResultHandler
	{
		public void SuccessFinish()
		{
			Debug.Log("Success finish");
		}

		public void FailFinish()
		{
		}
	}
}