using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptble Object/WeaponData")]
public class WeaponData : ScriptableObject
{
    //패시브 스탯
<<<<<<< Updated upstream
    [Header("#레벨별 스폰지연시간")]
    public float[] speed;
    [Header("#레벨별 공격력")]
=======
    [Header("#투사체 속도(방향)")]
    public float[] speed;
    [Header("#관통력")]
>>>>>>> Stashed changes
    public float[] count;
}
