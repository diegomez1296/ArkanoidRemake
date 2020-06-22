using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    #region CONSTANS
    public const int MAX_AMOUNT_OF_BLOCKS_IN_MAP = 270;
    public const int MAPS_PATTERN_AMOUNT = 2;
    public const int START_BALL_SPEED = 500;
    public const int BONUSES_AMOUNT = 4;
    public const float BLOCK_HEIGHT = 0.4f;
    public const float BLOCK_WIDTH = 1;
    public static string SAVES_PATH;
    #endregion

    public static GameController Instance;

    private static bool isGameRunning = false;
    public static bool IsGameRunning {get { return isGameRunning; } set { isGameRunning = value; Cursor.visible = !isGameRunning; } }

    public GameData Data { get; private set; }
    public SaveController Save { get; private set; }
    public AudioController Audio { get; private set; }

    #region METHODS
    private void Awake() => Instance = this;

    private void Start()
    {
        Data = GetComponentInChildren<GameData>();
        Save = GetComponentInChildren<SaveController>();
        Audio = GetComponentInChildren<AudioController>();

        SAVES_PATH = Application.dataPath + "/StreamingAssets/Saves/";
        Save.LoadGame();
        StartCoroutine(LoadLevels());
    }

    private IEnumerator LoadLevels()
    {
        yield return SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.5f);
        Data.CreateDataBlocks(); 
    }

    public void StartNewGame()
    {
        Debug.Log("StartGame");
        GameData.CurrentScore = 0;
        CreateNewMap();
        SetGameUI();
        IsGameRunning = true;
        LevelController.Instance.ActivePlayer(3);
    }

    internal void LoadGame()
    {
        Debug.Log("LoadGame");
        GameData.CurrentScore = Save.SaveBlock.Currentscore;
        CreateNewMap(Save.SaveBlock);
        SetGameUI();
        IsGameRunning = true;
        LevelController.Instance.ActivePlayer(Save.SaveBlock.PlankHP);
    }

    private void SetGameUI()
    {
        UIController.Instance.SetGameUI();
    }

    private void CreateNewMap(SaveController.SaveGameBlock saveGameBlock = null)
    {
        Map map = LevelController.Instance.Map;
        map.CurrentState = saveGameBlock != null ? GetMap(map, Save.SaveBlock.BlocksOfMap.CurrentMapState) : GetMap(map, UnityEngine.Random.Range(0, MAPS_PATTERN_AMOUNT));
        map.GenerateMap(saveGameBlock);
    }

    public void CreateBonus(Block block, BonusState bonusState = null)
    {
        Bonus bonus = Instantiate(Data.bonusPrefab, block.transform.parent);
        bonus.SetPosition(block.transform.position);
        if (bonusState != null) bonus.CurrentState = bonusState;
        else bonus.CurrentState = GetBonus(bonus, UnityEngine.Random.Range(0, BONUSES_AMOUNT));
        bonus.IsUsed = false;
        bonus.gameObject.SetActive(true);
        bonus.GetComponent<Rigidbody2D>().isKinematic = false;
    }
    public void LoseGame()
    {
        IsGameRunning = false;
        UIController.Instance.Game.pausePanel.ShowGameOver();
    }

    private BonusState GetBonus(Bonus bonus, int param)
    {
        switch (param)
        {
            case 0:
                return new ExtraLifeBonusState(bonus);
            case 1:
                return new SmallerSizeBonusState(bonus);
            case 2:
                return new BiggerSizeBonusState(bonus);
            case 3:
                return new DeadBonusState(bonus);
            case 10:
                return new SlowerBallBonusState(bonus);
            default:
                return null;
        }
    }

    public BlockState GetBlock(Block block, int param)
    {
        switch (param)
        {
            case 0:
                return new DefaultBlockState(block);
            case 1:
                return new GlassBlockState(block);
            case 2:
                return new SolidBlockState(block);
            case 3:
                return new TNTBlockState(block);
            default:
                return null;
        }
    }

    public int BlockStateToInt(BlockState block)
    {
        if (typeof(DefaultBlockState).IsInstanceOfType(block)) return 0;
        if (typeof(GlassBlockState).IsInstanceOfType(block)) return 1;
        if (typeof(SolidBlockState).IsInstanceOfType(block)) return 2;
        if (typeof(TNTBlockState).IsInstanceOfType(block)) return 3;
        else return -10;
    }
    
    private MapState GetMap(Map map, int param)
    {
        switch (param)
        {
            case 0:
                return new RectangleMapState(map);
            case 1:
                return new TriangleMapState(map);
            default:
                return null;
        }
    }
    

    public int MapStateToInt(MapState map)
    {
        if (typeof(RectangleMapState).IsInstanceOfType(map)) return 0;
        if (typeof(TriangleMapState).IsInstanceOfType(map)) return 1;
        else return -1;
    }
    

    internal void CreateSave(bool isGameOver)
    {
        bool saveMap = !isGameOver;

        Save.CreateSave(saveMap);
    }

    internal void CheckHighscore(int currentScore)
    {
        GameData.HighScore = currentScore > GameData.HighScore ? currentScore : GameData.HighScore;
    }

    #endregion
}
