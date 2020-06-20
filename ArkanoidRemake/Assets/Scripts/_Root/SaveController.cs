using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public class SaveGameBlock
    {
        public int Highscore { get; set; }
        public Map Map { get; set; }
        public Plank Plank { get; set; }

        public SaveGameBlock(int highscore, Map map, Plank plank)
        {
            Highscore = highscore;
            Map = map;
            Plank = plank;
        }
    }

    public SaveGameBlock SaveBlock { get; private set; }

    public void SaveGame(SaveGameBlock saveGameBlock) 
    {
        SaveToFile(saveGameBlock);
    }

    public void LoadGame()
    {
        SaveBlock = ReadFromFile();
    }

    private void SaveToFile(SaveGameBlock saveGameBlock)
    {
        try
        {
            string path = GameController.SAVES_PATH + "Save_" + 0 + ".arc";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Create);
            using (BinaryWriter binaryWriter = new BinaryWriter(fs))
            {
                formatter.Serialize(fs, saveGameBlock);
            }
        }
        catch (IOException e)
        {
            Debug.LogError(saveGameBlock);
            Debug.LogError(e.Message);
        }
    }

    private SaveGameBlock ReadFromFile()
    {
        try
        {
            string path = GameController.SAVES_PATH + "Save_" + 0 + ".arc";
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            using (BinaryReader binaryReader = new BinaryReader(fs))
            {
                return (SaveGameBlock)formatter.Deserialize(fs);
            }
        }
        catch (IOException e)
        {
            Debug.LogError(e.Message);
            return null;
        }
    }
}
