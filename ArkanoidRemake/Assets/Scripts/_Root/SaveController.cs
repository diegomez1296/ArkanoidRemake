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
        public List<Block> BlocksOfMap { get; set; }
        public float PlankHP { get; set; }

        public SaveGameBlock(int highscore, int currentscore, List<Block> blocksOfMap, float plankHP)
        {
            Highscore = highscore;
            Currentscore = currentscore;
            BlocksOfMap = blocksOfMap;
            PlankHP = plankHP;
        }
    }

    public SaveGameBlock SaveBlock { get; private set; }


    public void CreateSave()
    {
        SaveBlock = new SaveGameBlock
                    (GameData.CurrentScore > GameData.HighScore ? GameData.CurrentScore : GameData.HighScore, GameData.CurrentScore,
                    GameData.blocksOfMap, LevelController.Instance.Plank.HP);

        SaveGame();
    }

    private void SaveGame() 
    {
        SaveToFile(SaveBlock);
    }

    public void LoadGame()
    {
        SaveBlock = ReadFromFile();
        //Debug.Log(SaveBlock.Highscore);
        //Debug.Log(SaveBlock.Map);
        //Debug.Log(SaveBlock.Plank);
    }

    private void SaveToFile(SaveGameBlock saveGameBlock)
    {
        string path = GameController.SAVES_PATH;
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string saveStr = JsonUtility.ToJson(saveGameBlock);
        try
        {
            File.WriteAllText(path + "Save_" + 0 + ".arc", JsonUtility.ToJson(saveGameBlock));
        }
        catch (IOException e)
        {
            Debug.LogError("value: " + saveStr);
            Debug.LogError(e.Message);
        }
    }

    private SaveGameBlock ReadFromFile()
    {
        string path = GameController.SAVES_PATH + "Save_" + 0 + ".arc";
        try
        {
            return JsonUtility.FromJson<SaveGameBlock>(File.ReadAllText(path));
        }
        catch (IOException e)
        {
            Debug.LogError(e.Message);
            return null;
        }
    }
}
