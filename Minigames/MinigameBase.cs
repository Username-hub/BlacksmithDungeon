using UnityEngine;

namespace Minigames
{
    public abstract class MinigameBase : MonoBehaviour
    {
        public MinigameManager minigameManager;

        public abstract void MinigameStart(MinigameManager minigameManager);
    }
}