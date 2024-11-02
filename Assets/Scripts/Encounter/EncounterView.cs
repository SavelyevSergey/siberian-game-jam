using System;
using System.Collections.Generic;
using Entities;
using Sirenix.OdinInspector;
using Skills;
using UnityEngine;

namespace Encounter
{
    public class EncounterView : MonoBehaviour
    {
        [SerializeField] private List<SkillForEncounterModel> _playerSkillsOrder;
        [SerializeField] private List<AEntity> _enemies;
        
        private Action<List<SkillForEncounterModel>> _launchCallback;

        public void SetEnemies(List<AEntity> enemies)
        {
            _enemies = enemies;
        }
        
        public void SetSkills(List<SkillModel> skills)
        {
            _playerSkillsOrder = new();
            foreach (var skill in skills)
            {
                _playerSkillsOrder.Add(new SkillForEncounterModel(skill));
            }
        }

        public void Listen(Action<List<SkillForEncounterModel>> onLaunch)
        {
            _launchCallback = onLaunch;
        }

        [Button]
        public void Launch()
        {
            _launchCallback.Invoke(_playerSkillsOrder);
        }
    }
}