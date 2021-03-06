using System;
using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    public  class Player:MonoBehaviour
    {

        [Serializable]
        public class Save
        {
            public string Name;
            public int RecordScore;
        }

        public static Player instance;
        public string Name { get; set; }
        public int Record { get; set; }

        public void Awake()
        {
            if(instance!=null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
        public void SaveData()
        {
            Save save = new Save();
            save.Name = Name;
            save.RecordScore = Record;
            string json = JsonUtility.ToJson(save);
            File.WriteAllText(Application.persistentDataPath + "data1.json", json);
            Debug.Log("Save");
        }
        public void LoadData()
        {
            
            string path = Application.persistentDataPath + "data1.json";
            if (File.Exists(path))
            {
                string json= File.ReadAllText(path); 
                Save data = JsonUtility.FromJson<Save>(json);
                Debug.Log("Load");
                Name = data.Name;
                Record = data.RecordScore;
                
            }
        }


       

    }
}
