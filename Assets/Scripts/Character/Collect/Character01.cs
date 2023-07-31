using Character.Interface;
using Collection.Character;
using UnityEngine;

namespace Character
{
    public class Character01 : CharacterBase
    {
        [SerializeField] private Character01StatsCollection collection;

        protected override void Awake()
        {
            // CharacterStats01
            base.Awake();
            characterStats = collection.data;
        }

        //Health Other Target as 30% Hp
        protected override void Skill1()
        {
            var ray = CameraMain.ScreenPointToRay(Input.mousePosition);
            var mouse = Input.mousePosition;
            if (Physics.Raycast(ray, out var hit))
            {
                var character = hit.collider.GetComponent<ICharacter>();
                character?.Healing(0, 0.3f);
            }
        }

        protected override void Skill2()
        {
            Debug.Log("Flame Ball");
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