using UnityEngine;

namespace Minigames
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MinigameObject", order = 0)]
    public class MinigameObject : ScriptableObject
    {
        public int minigameId;
        public Sprite WeaponSprite;
    }
}