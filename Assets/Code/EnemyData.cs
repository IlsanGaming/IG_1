using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptble Object/EnemyData")]
public class EnemyData : ScriptableObject
{
    //패시브 스탯
    [Header("#레벨별 스폰지연시간")]
    public float[] spawnTime;
    [Header("#레벨별 공격력")]
    public float[] damage;
    [Header("레벨별 최대체력")]
    public float[] health;
    [Header("#레벨별 이동속도")]
    public float[] speed;
    [Header("#레벨별 넉백 지속시간")]
    public float[] time;
    [Header("#레벨별 넉백 저항도(높을수록 약함)")]
    public float[] lightness;
    [Header("#적 ID")]
    public int id;


    [Header("#공격 재사용 대기시간")]
    public float[] skillcool;
    [Header("#투사체 속도")]
    public float[] skillspeed;
    [Header("#공격 시전횟수")]
    public float[] skillcount;
    [Header("#공격 피해량")]
    public float[] skilldamage;
    [Header("#처치시 경험치 드랍")]
    public int[] exp;
}
