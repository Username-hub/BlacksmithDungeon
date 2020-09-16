using UnityEngine;

namespace Minigames
{
    public abstract class MinigameBase : MonoBehaviour
    {
        public MinigameManager minigameManager;
        public float gameTimer;

        public abstract void MinigameStart(MinigameManager minigameManager);
    }
}