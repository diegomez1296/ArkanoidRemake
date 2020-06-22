using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMapState : MapState
{
    public TriangleMapState(Map map) : base(map)
    {
    }

    protected override void Initialize()
    {
        map.Rows = 10;
        map.Columns = 10;
        map.StartPosition = new Vector2(-5.5f, 3.7f);
        map.OnGenerated -= OnGenerate;
        map.OnGenerated += OnGenerate;
    }

    protected override void OnGenerate(SaveController.SaveGameBlock saveGameBlock)
    {
        GameController.Instance.Data.ClearDataBlocks();

        int idx = 0;
        float x = map.StartPosition.x;
        float y = map.StartPosition.y;

        for (int i = map.Columns; i >= 0; i--)
        {
            for (int j = i; j >= 0; j--)
            {
                x += GameController.BLOCK_WIDTH;
                idx++;
            }

            for (int j = i; j < map.Columns; j++)
            {
                GameData.blocksOfMap[idx].SetPosition(new Vector2(x, y));
                if (saveGameBlock == null)
                    GameData.blocksOfMap[idx].CurrentState = RandomBlock(GameData.blocksOfMap[idx]);
                else
                    GameData.blocksOfMap[idx].CurrentState = GameController.Instance.GetBlock(GameData.blocksOfMap[idx], saveGameBlock.BlocksOfMap.CurrentBlocks[idx]);

                if (GameData.blocksOfMap[idx].CurrentState != null)
                    GameData.blocksOfMap[idx].gameObject.SetActive(true);
                x += GameController.BLOCK_WIDTH;
                idx++;
            }
            x = map.StartPosition.x;
            y -= GameController.BLOCK_HEIGHT;
        }

        map.CheckDestroyedBlocks();
    }

    protected override BlockState RandomBlock(Block block)
    {
        int randValue = UnityEngine.Random.Range(0, 100);

        if (randValue < 50)
        {
            return GameController.Instance.GetBlock(block, 0); //50% for default block
        }
        else if (randValue >= 50 && randValue < 90)
        {
            return GameController.Instance.GetBlock(block, 1); //40% for glass block
        }
        else if (randValue >= 90 && randValue < 95)
            return GameController.Instance.GetBlock(block, 2); //5% for solid block
        else
            return null; //5% for empty space
    }
}
