namespace Character.Interface
{
    public interface ICharacter
    {
        void EarnDamage(float damage, DamageShieldType damageShieldType);
        void Attack(float damage);
        void Die();
        void GrievousWounds(float timeWounds);
        void Healing(float timeHealing, float healthRating = 0, float healthPoint = 0);

        void HealPerSecond(float healthPoint);
        void Shield(float timeShield, DamageShieldType damageShieldType, float shieldRating = 0, float shieldPoint = 0);
        void BoostSpeed(float timeBoosting, float speedBoostRating);
        void SlowSpeed(float timeSlow, float speedSlowRating, SlowType slowType);
        void BoostHealth(float healthRating = 0, float healthInstance = 0);
        void Stun(float timeStun);
        void AirBorne(float timeAirBorne);
    }

    public enum DamageShieldType
    {
        All = 0,
        Physic = 1,
        Magic = 2
    }

    public enum SlowType
    {
        Slower=0,Faster=1,None=2,
    }
}