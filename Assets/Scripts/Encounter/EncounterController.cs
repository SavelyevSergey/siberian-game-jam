using System.Collections.Generic;
using System.Linq;
using Entities;
using Sirenix.OdinInspector;
using Skills;
using UnityEngine;

namespace Encounter
{
    public class EncounterController : MonoBehaviour
    {
        [SerializeField] private EncounterView _encounterView;

        private Dictionary<string, AEntity> _entities;
        private Dictionary<string, List<EncounterStep>> _steps;

        private List<string> _stepOrder;
        private List<EncounterStep> _stepQueue;

        private EntityFactory _factory;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            _factory = new();
            _steps = new();
        }

        public void SetupEncounter(EncounterModel model)
        {
            _steps.Clear();
            _stepOrder = model.StepOrder;
            
            //setting up entities & steps
            _entities = new();
            
            var hero = _factory.Make(model.Hero, "Hero");
            _entities["Hero"] = hero;

            foreach (var enemy in model.Enemies)
            {
                _entities[enemy.Id] = _factory.Make(enemy.Model, enemy.Id);
                _steps[enemy.Id] = new();
                foreach (var skill in enemy.SkillOrder)
                {
                    _steps[enemy.Id].Add(new(_entities[enemy.Id], skill.Skill, hero));
                }
            }
            
            _steps["Hero"] = new();
            foreach (var skill in model.HeroSkillOrder)
                _steps["Hero"].Add(new(hero, skill.Skill.Skill, _entities[skill.Target]));
            
            var player = _factory.MakePlayer();
            _entities["Player"] = player;
            _steps["Player"] = new();
            
            //setting up view
            var enemies = new List<AEntity>();
            foreach (var entity in _entities)
                if (entity.Key != "Hero" && entity.Key != "Player")
                    enemies.Add(entity.Value);
            _encounterView.SetEnemies(enemies);
            _encounterView.SetSkills(model.PlayerSkills);
            _encounterView.Listen(OnLaunch);
        }

        private void OnLaunch(List<SkillForEncounterModel> playerSkillOrder)
        {
            Debug.Log("Player Ready!");
            for (var i = 0; i < _steps["Hero"].Count; i++)
            {
                _steps["Player"].Add(new(_entities["Player"], playerSkillOrder[i].Skill.Skill, _entities[playerSkillOrder[i].Target]));
            }

            _stepQueue = new();
            for (var i = 0; i < _steps["Hero"].Count; i++)
            {
                for (var j = _stepOrder.Count - 1; j >= 0; j--)
                    _stepQueue.Add(_steps[_stepOrder[j]][i]);
            }

            MakeStep();
        }

        [Button]
        private void MakeStep()
        {
            if (_stepQueue.Count == 0)
            {
                Debug.Log("VICTORY!!!!!!");
                return;
            }

            var step = _stepQueue[^1];
            _stepQueue.RemoveAt(_stepQueue.Count - 1);
            
            Debug.Log($"{step.Actor.Id} uses skill {step.Skill.Name} on {step.Target.Id}");
            step.Skill.Apply(step.Target);
            if (_entities[step.Target.Id].IsDead)
            {
                if (step.Target.Id == "Hero")
                {
                    Debug.Log("DEFEAT!!!!!!");
                    _stepQueue.Clear();
                    return;
                }
                else
                {
                    var i = _stepQueue.Count - 1;
                    while (i >= 0)
                    {
                        var actor = _stepQueue[i].Actor;

                        if (actor.Id == "Hero" || actor.Id == "Player")
                        {
                            i--;
                            continue;
                        }
                        if (actor.IsDead)
                            _stepQueue.RemoveAt(i);
                        i--;
                    }

                    if (_stepQueue.All(s => s.Actor.Id == "Hero" || s.Actor.Id == "Player"))
                    {
                        Debug.Log("VICTORY!!!!!!");
                        _stepQueue.Clear();
                        return;
                    }
                }
            }
        }
        
        private class EncounterStep
        {
            public AEntity Actor;
            public ASkill Skill;
            public AEntity Target;

            public EncounterStep(AEntity actor, ASkill skill, AEntity target)
            {
                Actor = actor;
                Skill = skill;
                Target = target;
            }

        }
    }
}