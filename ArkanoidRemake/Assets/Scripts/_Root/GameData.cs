using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public static List<Block> blocksOfMap = new List<Block>();

    //Resolution X
    public static float ResMinX => 0 - Camera.main.aspect * 5;
    public static float ResMaxX => 0 + Camera.main.aspect * 5;

    private static int highScore;
    public static int HighScore
    {
        get { return highScore; }
        set { highScore = value; UIController.Instance.Game.SetHighScore(); }
    }

    private static int currentScore;
    public static int CurrentScore
    {
        get { return currentScore; }
        set { currentScore = value; UIController.Instance.Game.SetCurrentScore(); }
    }


    public GameObject plankPrefab;
    public List<Sprite> plankSprites;
    [Space]
    public Block blockPrefab;
    public List<Sprite> blockSprites;
    [Space]
    public GameObject ballPrefab;
    public List<Sprite> ballSprites;
    [Space]
    public Bonus bonusPrefab;
    public List<Sprite> bonusSprites;
    [Space]
    public List<Texture2D> backgroundImages;
    [Space]
    public List<Sprite> lifeSprites;
    [Space]
    public List<AudioClip> audioClips;


    internal void CreateDataBlocks()
    {
        blocksOfMap.Clear();
        for (int i = 0; i < GameController.MAX_AMOUNT_OF_BLOCKS_IN_MAP; i++)
        {
            Block block = Instantiate(blockPrefab, LevelController.Instance.Map.transform);
            block.gameObject.SetActive(false);
            blocksOfMap.Add(block);
        }
    }

    internal void ClearDataBlocks()
    {
        foreach (var item in blocksOfMap)
        {
            item.gameObject.SetActive(false);
            item.isUsed = false;
        }
    }
}
