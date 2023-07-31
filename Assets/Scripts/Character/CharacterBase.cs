using System.Collections;
using Character;
using Character.Interface;
using Character.Skill;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class CharacterBase : MonoBehaviour, ICharacter
{
    [SerializeField] protected CharacterStaticStats[] characterStats;
    [SerializeField] protected SkillStats skillStats;
    [SerializeField] protected CharacterDynamicStats characterDynamicStats;
    [SerializeField] protected float[] timeCooldown;
    protected Camera CameraMain;
    [SerializeField] protected int characterId;

    //in game stats
    [SerializeField] private float currentHealth;
    protected int Exp;
    protected int Level;
    protected float CurrentSpeed;
    protected bool IsWounds;

    // Update is called once per frame
    protected virtual void Awake()
    {
        CameraMain = Camera.main;
        characterDynamicStats = new CharacterDynamicStats(characterStats[0]);
        currentHealth = characterDynamicStats.health;
        CurrentSpeed = characterDynamicStats.moveSpeed;
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && timeCooldown[0] <= 0)
        {
            Skill1();
        }

        if (Input.GetKeyDown(KeyCode.W) && timeCooldown[1] <= 0)
        {
            Skill2();
        }

        if (Input.GetKeyDown(KeyCode.E) && timeCooldown[2] <= 0)
        {
            Skill3();
        }

        if (Input.GetKeyDown(KeyCode.R) && timeCooldown[3] <= 0)
        {
            Skill4();
        }

        AutoCooldown();
    }

    private void AutoCooldown()
    {
        for (var i = 0; i < timeCooldown.Length; i++)
        {
            if (timeCooldown[i] > 0)
            {
                timeCooldown[i] -= Time.deltaTime;
            }
        }
    }

    protected abstract void Skill1();

    protected abstract void Skill2();

    protected abstract void Skill3();

    protected abstract void Skill4();

    #region General

    public void EarnDamage(float damage)
    {
    }

    public void EarnDamage(float damage, DamageShieldType damageShieldType)
    {
    }

    public void Attack(float damage)
    {
    }

    public void Die()
    {
    }

    public void GrievousWounds(float timeWounds)
    {
    }

    protected IEnumerator BeWound(float timeWounds)
    {
        IsWounds = true;
        yield return new WaitForSeconds(timeWounds);
        IsWounds = false;
    }

    public void Healing(float timeHealing, float healthRating = 0, float healthPoint = 0)
    {
        StartCoroutine(Heal(timeHealing, healthRating, healthPoint));
    }

    public void HealPerSecond(float healthPoint)
    {
    }

    private IEnumerator Heal(float timeHealing, float healthRating = 0, float healthPoint = 0)
    {
        var time = timeHealing;
        do
        {
            if (healthPoint > 0)
            {
                currentHealth += healthPoint;
                if (currentHealth > characterDynamicStats.health)
                    currentHealth = characterDynamicStats.health;
            }

            if (healthRating > 0)
            {
                currentHealth += characterDynamicStats.health * healthRating;
                if (currentHealth > characterDynamicStats.health)
                    currentHealth = characterDynamicStats.health;
            }

            time -= 1;
            if (time > 1)
            {
                yield return new WaitForSeconds(1);
            }
        } while (time >= 0);
    }

    public void Shield(float timeShield, DamageShieldType damageShieldType, float shieldRating = 0,
        float shieldPoint = 0)
    {
    }

    public void BoostSpeed(float timeBoosting, float speedBoostRating)
    {
    }

    public void SlowSpeed(float timeSlow, float speedSlowRating, SlowType slowType)
    {
        StartCoroutine(BeSlow(timeSlow, speedSlowRating, slowType));
    }

    private IEnumerator BeSlow(float timeSlow, float speedSlowRating, SlowType slowType)
    {
        var currentTime = 0;
        switch (slowType)
        {
            case SlowType.Slower:
            {
                var ratingPerSecond = speedSlowRating / timeSlow;
                while (currentTime < timeSlow)
                {
                    CurrentSpeed -= characterDynamicStats.moveSpeed * ratingPerSecond;
                    currentTime += 1;
                    yield return new WaitForSeconds(1);
                }

                CurrentSpeed = characterDynamicStats.moveSpeed;
                break;
            }
            case SlowType.Faster:
            {
                var ratingPerSecond = speedSlowRating / timeSlow;
                CurrentSpeed -= characterDynamicStats.moveSpeed * speedSlowRating;
                while (currentTime < timeSlow)
                {
                    CurrentSpeed += characterDynamicStats.moveSpeed * ratingPerSecond;
                    currentTime += 1;
                    yield return new WaitForSeconds(1);
                }

                CurrentSpeed = characterDynamicStats.moveSpeed;
                break;
            }
            case SlowType.None:
            {
                CurrentSpeed -= characterDynamicStats.moveSpeed * speedSlowRating;
                while (currentTime < timeSlow)
                {
                    currentTime += 1;
                    yield return new WaitForSeconds(1);
                }

                CurrentSpeed = characterDynamicStats.moveSpeed;
                break;
            }
        }
    }

    public void BoostHealth(float healthRating = 0, float healthInstance = 0)
    {
    }

    public void Stun(float timeStun)
    {
    }

    public void AirBorne(float timeAirBorne)
    {
    }

    #endregion
}