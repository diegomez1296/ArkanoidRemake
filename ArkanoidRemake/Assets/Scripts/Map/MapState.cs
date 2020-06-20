using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapState : ArkanoidState
{
    protected Map map;

    protected MapState(Map map)
    {
        this.map = map;
        Initialize();
    }

    protected abstract void OnGenerate(); //This method describe how to generate map
    protected abstract BlockState RandomBlock(Block block); //This method describe how to create random block
}
