using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptble Object/PlayerData")]
public class PlayerData : ScriptableObject
{

    //패시브 스탯
    [Header("#레벨별 공격력 증가")]
    public float[] damage;
    [Header("레벨별 #최대체력")]
    public float[] health;
    [Header("#레벨별 이동속도")]
    public float[] speed;

    [Header("#스킬1 재사용 대기시간")]
    public float[] skill1cool;
}
