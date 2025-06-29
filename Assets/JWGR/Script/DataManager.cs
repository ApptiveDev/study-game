using UnityEngine;
using System.Collections;
using System.IO;

namespace JWGR
{
    public class PlayerData
    {
        public int level;
        public int money;
        public int item;
    }

    public class DataManager : MonoBehaviour
    {
        public static DataManager instance;

        private PlayerData nowPlayer = new PlayerData();
        private string path;
        private string data;
        private string filename = "save";

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            path = Application.persistentDataPath + "/";
        }

        private void SaveData()
        {
            data = JsonUtility.ToJson(nowPlayer);
            File.WriteAllText(path + filename, data);
        }

        private void LoadData()
        {
            data = File.ReadAllText(path + filename);
            nowPlayer = JsonUtility.FromJson<PlayerData>(data);
        }
    }
}