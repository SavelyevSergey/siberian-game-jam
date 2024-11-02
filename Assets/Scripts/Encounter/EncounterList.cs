using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Encounter
{
    [CreateAssetMenu(menuName = "Game/Lists/Encounters", fileName = "Encounter List")]
    public class EncounterList : ScriptableObject
    {
        [SerializeField] private List<EncounterModel> _encounters;

        public EncounterModel Get(string id)
        {
            return _encounters.FirstOrDefault(e => e.Id == id);
        }
    }
}