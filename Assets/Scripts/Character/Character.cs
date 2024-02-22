using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character
{
    public class Character:MonoBehaviour
    {
        public int id;
        public string nameCharacter;
        [SerializeReference,SubclassSelector] public CharacterSkill skill;

        private void Awake()
        {
            skill.Executed();
        }
    }

    [Serializable]
    public enum SkillType
    {
        Heal,
        Atk, 
        Def
    }

    [Serializable]
    public abstract class CharacterSkill
    {
        public SkillType skillType;
        public abstract void Executed();
    }

    [Serializable]
    public class CharacterSkill1 : CharacterSkill
    {
        
        public int def;
        public override void Executed()
        {
            Debug.Log(def);
        }
    }
    [Serializable]
    public class CharacterSkill2 : CharacterSkill
    {
        public int atk;
        public float speed;
        public override void Executed()
        {
            Debug.Log(atk);
        }
    }
    [Serializable]
    public class CharacterSkill3 : CharacterSkill
    {
        public int heal;
        public override void Executed()
        {
            Debug.Log(heal);
        }
    }

}