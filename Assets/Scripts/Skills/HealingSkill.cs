using System;
using Entities;
using UnityEngine;

namespace Skills
{
    [Serializable]
    public class HealingSkill : ASkill
    {
        [SerializeField] private int _amount;


        public override void Apply(AEntity entity)
        {
            entity.Heal(_amount);
        }
    }
}