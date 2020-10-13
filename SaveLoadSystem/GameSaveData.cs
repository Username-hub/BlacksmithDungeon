using UnityEngine.UIElements;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class GameSaveData
    {
        public int gold;
        public int XP;
        public int lvl;

        public GameSaveData(int gold,int lvl, int xp)
        {
            this.lvl = lvl;
            this.gold = gold;
            XP = xp;
        }
    }
}