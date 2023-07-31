using Character.Skill;
using UnityEngine;

namespace Collection.Character
{
    [CreateAssetMenu(menuName = "Character/SkillStats/character01", fileName = "character01Skill", order = 1)]
    public class CharacterSkillStats:ScriptableObject
    {
        public SkillStats[] skill1;
        public SkillStats[] skill2;
        public SkillStats[] skill3;
        public SkillStats[] skill4;
    }
}