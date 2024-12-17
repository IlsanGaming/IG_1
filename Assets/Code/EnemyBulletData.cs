using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyBulletData", menuName = "Scriptble Object/EnemyBulletData")]
public class EnemyBulletData : ScriptableObject
{
    //패시브 스탯
    [Header("#레벨별 데미지")]
    public float[] damage;

}
