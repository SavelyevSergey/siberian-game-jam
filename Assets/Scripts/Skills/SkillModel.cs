using System;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "Game/Models/Skill", fileName = "Skill")]
    public class SkillModel : ScriptableObject
    {
        [SerializeReference] private ASkill _skill;
        
        public ASkill Skill => _skill;
    }
}