using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveLoadSystem
{
    public static class SaveSystem
    {
        public static void SaveProgress(int gold,int lvl, int XP)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            String path = Application.persistentDataPath + "save.bin";
            FileStream fileStream = new FileStream(path, FileMode.Create);
            GameSaveData gameSaveData = new GameSaveData(gold,lvl, XP);
            binaryFormatter.Serialize(fileStream, gameSaveData);
            fileStream.Close();
        }

        public static GameSaveData LoadProgress()
        {
            String path = Application.persistentDataPath + "save.bin";
            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(path, FileMode.Open);
                if (fileStream.Length == 0)
                {
                    fileStream.Close();
                    return new GameSaveData(0, 0, 0);
                }

                GameSaveData gameSaveData = binaryFormatter.Deserialize(fileStream) as GameSaveData;
                fileStream.Close();
                return gameSaveData;
            }
            else
            {
                return new GameSaveData(0, 0, 0);
            }
        }
    }
}