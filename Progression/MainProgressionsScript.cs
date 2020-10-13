using System;
using SaveLoadSystem;
using UnityEngine;

namespace Progression
{
    public static class MainProgressionsScript
    {

        public static void SaveRunProgress(int gold, int xp, int lvl)
        {
            SaveSystem.SaveProgress(gold, xp, lvl);
        }
    }
}