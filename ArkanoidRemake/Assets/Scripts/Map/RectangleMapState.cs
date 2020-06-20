using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleMapState : MapState
{
    public RectangleMapState(Map map) : base(map)
    {
    }

    protected override void Initialize()
    {
        Debug.Log("MAP INIT");
        map.Rows = 7;
        map.Columns = 8;
        map.StartPosition = new Vector2(-4.5f, 0.9f);
        map.OnGenerate -= OnGenerate;
        map.OnGenerate += OnGenerate;
    }

    protected override void OnGenerate()
    {
        Debug.Log("MAP OnGenerate");


        int idx = 0;
        float x = map.StartPosition.x;
        float y = map.StartPosition.y;

        for (int i = 0; i < map.Rows; i++)
        {
            for (int j = 0; j < map.Columns; j++)
            {
                GameData.blockOfMap[idx].SetPosition(new Vector2(x, y));
                GameData.blockOfMap[idx].CurrentState = RandomBlock(GameData.blockOfMap[idx]);
                if (GameData.blockOfMap[idx].CurrentState != null)
                    GameData.blockOfMap[idx].gameObject.SetActive(true);

                x += GameController.BLOCK_WIDTH;
                idx++;
            }
            x = map.StartPosition.x;
            y += GameController.BLOCK_HEIGHT;
        }
    }

    protected override BlockState RandomBlock(Block block)
    {
        int randValue = UnityEngine.Random.Range(0, 100);

        if (randValue < 70)
            return GameController.Instance.GetBlock(block, 0); //70% for default block
        else if (randValue >= 70 && randValue < 90)
            return GameController.Instance.GetBlock(block, 1); //20% for glass block
        else if (randValue >= 90 && randValue < 95)
            return GameController.Instance.GetBlock(block, 2); //5% for solid block
        else
            return null; //5% for empty space
    }
}
