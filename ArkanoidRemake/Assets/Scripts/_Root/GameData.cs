using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{

    //Resolution X
    public static float ResMinX => 0 - Camera.main.aspect * 5;
    public static float ResMaxX => 0 + Camera.main.aspect * 5;


    public GameObject plankPrefab;
    public List<Sprite> plankSprites;
    [Space]
    public GameObject blockPrefab;
    public List<Sprite> blockSprites;
    [Space]
    public GameObject ballPrefab;
    public List<Sprite> ballSprites;
    [Space]
    public GameObject bonusPrefab;
    public List<Sprite> bonusSprites;
    [Space]
    public List<Texture2D> backgroundImages;
}
