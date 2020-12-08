using System;
using UnityEngine;

namespace Minigames
{
    public enum Status
    {
        Have,
        CanBuy,
        Blocked
    };
    
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MinigameObject", order = 0)]
    public class MinigameObject : ScriptableObject
    {
        public Status status;
        public int minigameId;
        public Sprite WeaponSprite;
        public int price;
        public String description;
    }
}