using Character.Interface;
using Collection.Character;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character.Collect
{
    public class Character01 : CharacterBase
    {
        [FormerlySerializedAs("collection")] [SerializeField] private CharacterStatsCollection staticStats;
        [SerializeField] private  CharacterSkillStats skillStatus;
        protected override void Awake()
        {
            // CharacterStats01
            characterStats = staticStats.data;
            timeCooldown[0] = 0;
            timeCooldown[1] = 0;
            timeCooldown[2] = 0;
            timeCooldown[3] = 0;
            base.Awake();

        }

        //Health Other Target as 30% Hp
        protected override void Skill1()
        {
            var ray = CameraMain.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                var character = hit.collider.GetComponent<ICharacter>();
                character?.Healing(0, 0.3f);
                timeCooldown[0] = skillStatus.skill1[0].timeCooldown;
            }
        }

        protected override void Skill2()
        {
            var ray = CameraMain.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                var character = hit.collider.GetComponent<ICharacter>();
                character?.SlowSpeed(5, 0.7f, SlowType.Faster);
                timeCooldown[1] = skillStatus.skill2[0].timeCooldown;
            }
        }

        protected override void Skill3()
        {
            Debug.Log("Flame Shock");
        }

        protected override void Skill4()
        {
            Debug.Log("Flame Bound");
        }
    }
}