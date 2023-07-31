namespace Character.Interface
{
    public interface ICharacter
    {
        void EarnDamage(float damage);
        void Attack(float damage);
        void Die();
        void GrievousWounds(float timeWounds);
        void Healing(float timeHealing, float healthRating = 0,float healthPoint=0);
        void BoostSpeed(float timeBoosting,float speedBoostRating);
        void SlowSpeed(float timeSlow, float speedSlowRating);
        void BoostHealth(float healthRating = 0, float healthInstance = 0);
    }
}