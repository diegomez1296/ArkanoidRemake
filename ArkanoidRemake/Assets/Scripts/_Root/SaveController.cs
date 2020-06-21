using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    [Serializable]
    public class SaveGameBlock
    {
        public int Highscore { get; set; }
        public int Currentscore { get; set; }
        public SerializeMap BlocksOfMap { get; set; }

        public float PlankHP { get; set; }

        public SaveGameBlock(int highscore, int currentscore, SerializeMap blocksOfMap, float plankHP)
        {
            Highscore = highscore;
            Currentscore = currentscore;
            BlocksOfMap = blocksOfMap;
            PlankHP = plankHP;
        }

        public SaveGameBlock(int highscore)
        {
            Highscore = highscore;
            Currentscore = 0;
            BlocksOfMap = null;
            PlankHP = 0;
        }
    }

    public SaveGameBlock SaveBlock { get; private set; }


    public void CreateSave(bool saveMap)
    {
        if (saveMap)
        {
            SaveBlock = new SaveGameBlock
                        (GameData.CurrentScore > GameData.HighScore ? GameData.CurrentScore : GameData.HighScore, GameData.CurrentScore,
                        LevelController.Instance.PrepareMapToSave(), LevelController.Instance.Plank.HP);
        }
        else
        {
            SaveBlock = new SaveGameBlock(GameData.CurrentScore > GameData.HighScore ? GameData.CurrentScore : GameData.HighScore);
        }

        SaveGame();
    }

    private void SaveGame()
    {
        SaveToFile(SaveBlock);
    }

    public void LoadGame()
    {
        SaveBlock = ReadFromFile();
        GameData.HighScore = SaveBlock != null ? SaveBlock.Highscore : 0;
    }

    private void SaveToFile(SaveGameBlock saveGameBlock)
    {
        string path = GameController.SAVES_PATH;
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            using (FileStream fs = new FileStream(path + "Save_" + 0 + ".arc", FileMode.Create))
            {

                formatter.Serialize(fs, saveGameBlock);

            }
        }
        catch (IOException e)
        {
            Debug.LogError("value: " + saveGameBlock);
            Debug.LogError(e.Message);
        }

    }

    private SaveGameBlock ReadFromFile()
    {
        string path = GameController.SAVES_PATH + "Save_" + 0 + ".arc";

        try
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {

                BinaryFormatter formatter = new BinaryFormatter();
                return (SaveGameBlock)formatter.Deserialize(fs);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            return null;
        }
    }
}
