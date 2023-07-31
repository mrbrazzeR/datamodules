using Collection.Character;
using UnityEngine;

namespace Character.Collect
{
    public class Character02 : CharacterBase
    {
        [SerializeField] private CharacterStatsCollection collection;
        [SerializeField] private  CharacterSkillStats skillStatus;
        protected override void Awake()
        {
            characterStats = collection.data;
            timeCooldown[0] = 0;
            timeCooldown[1] = 0;
            timeCooldown[2] = 0;
            timeCooldown[3] = 0;
            // CharacterStats01
            base.Awake();
        }

        protected override void Skill1()
        {
        }

        protected override void Skill2()
        {
        }

        protected override void Skill3()
        {
        }

        protected override void Skill4()
        {
        }
    }
}