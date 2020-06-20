using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public const int START_BALL_SPEED = 500;
    public const int BONUSES_AMOUNT = 3;
    public const int MAPS_PATTERN_AMOUNT = 1;
    public const int MAX_AMOUNT_OF_BLOCKS_IN_MAP = 270;
    public const float BLOCK_WIDTH = 1;
    public const float BLOCK_HEIGHT = 0.4f;
    public static string SAVES_PATH;

    public static GameController Instance;
    public static bool isGameRunning = false;


    public GameData Data { get; private set; }
    public SaveController Save { get; private set; }
    public AudioController Audio { get; private set; }

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
        yield return new WaitForSeconds(1f);
        Data.CreateDataBlocks(); 
    }

    public void StartGame()
    {
        Map map = LevelController.Instance.Map;

        GameData.CurrentScore = 0;
        map.CurrentState = GetRandomMap(map, UnityEngine.Random.Range(0, MAPS_PATTERN_AMOUNT));
        map.GenerateMap(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("F1 clicked");
            StartGame();
        }
    }

    public void CreateBonus(Block block, BonusState bonusState = null)
    {
        Bonus bonus = Instantiate(Data.bonusPrefab, block.transform.parent);
        bonus.SetPosition(block.transform.position);
        if (bonusState != null) bonus.CurrentState = bonusState;
        else bonus.CurrentState = GetBonus(bonus, UnityEngine.Random.Range(0, BONUSES_AMOUNT));
        bonus.isUsed = false;
        bonus.gameObject.SetActive(true);
        bonus.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public void LoseGame()
    {

    }


    private BonusState GetBonus(Bonus bonus, int param)
    {
        switch (param)
        {
            case 0:
                return new ExtraLifeBonusState(bonus);
            case 1:
                return new SlowerBallBonusState(bonus);
            case 2:
                return new DeadBonusState(bonus);
            default:
                return null;
        }
    }

    public BlockState GetBlock(Block block, int param)
    {
        switch (param)
        {
            case 0:
                Debug.Log("Def block");
                return new DefaultBlockState(block);
            case 1:
                Debug.Log("Glass block");
                return new GlassBlockState(block);
            case 2:
                Debug.Log("Solid block");
                return new SolidBlockState(block);
            case 3:
                return new TNTBlockState(block);
            default:
                return null;
        }
    }

    private MapState GetRandomMap(Map map, int param)
    {
        switch (param)
        {
            case 0:
                return new RectangleMapState(map);
            default:
                return null;
        }
    }

}
