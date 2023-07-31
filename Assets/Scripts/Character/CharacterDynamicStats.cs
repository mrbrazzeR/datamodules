using System;

namespace Character
{
    [Serializable]
    public class CharacterDynamicStats
    {
        public float health;
        public float physicDamage;
        public float abilityPower;
        public float physicResist;
        public float magicResist;
        public float attackSpeed;
        public float attackRange;
        public float criticalRate;
        public float moveSpeed;
        public float armorPenetration;
        public float magicPenetration;

        public CharacterDynamicStats(CharacterStaticStats character)
        {
            health = character.health;
            physicDamage = character.physicDamage;
            abilityPower = character.abilityPower;
            physicResist = character.physicResist;
            magicResist = character.magicResist;
            attackSpeed = character.attackSpeed;
            attackRange = character.attackRange;
            moveSpeed = character.moveSpeed;
        }
    }
}