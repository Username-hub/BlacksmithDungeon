using UnityEngine;

namespace Minigames.SwordMinigame
{
    public class SwordScript : MonoBehaviour
    {
        public SwordMinigameScript minigameBase;
        public void HitAim()
        {
            minigameBase.AimGetHit();
        }
    }
}