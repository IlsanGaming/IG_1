using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData", menuName = "Scriptble Object/GameData")]
public class GameData : ScriptableObject
{
    //패시브 스탯
    [Header("#경험치통")]
    public int[] nextexp;
}
