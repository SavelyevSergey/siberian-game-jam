using System;
using Entities;
using UnityEngine;

namespace Skills
{
    [Serializable]
    public class HealingSkill : ASkill
    {
        [SerializeField] private int _amount;

        public override string Name => "Healing Skill";
        
        public override void Apply(AEntity entity)
        {
            Debug.Log($"entity {entity.Id} restores {_amount} hp");
            entity.Heal(_amount);
        }
    }
}