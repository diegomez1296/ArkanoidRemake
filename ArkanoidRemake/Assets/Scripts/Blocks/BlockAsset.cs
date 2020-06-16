using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Block", menuName = "Arkanoid/NewBlock", order = 1500)]
public class BlockAsset : ScriptableObject
{
    public float _hp;
    public float _score;
    public float _bonus;
    public List<Sprite> Sprites;
    public List<AudioClip> AudioClips;
}