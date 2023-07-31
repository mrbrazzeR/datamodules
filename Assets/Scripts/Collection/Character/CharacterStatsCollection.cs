using Character;
using UnityEngine;

namespace Collection.Character
{
    [CreateAssetMenu(menuName = "Character/StaticStats/character01", fileName = "character01", order = 1)]
    public class CharacterStatsCollection : ScriptableObject
    {
        public CharacterStaticStats[] data;
    }
}