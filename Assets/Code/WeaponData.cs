using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptble Object/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("투사체 속도(원거리 전용)")]
    public float[] bulletspeed;
    [Header("투사체 속도(방향)")]
    public float[] speed;
    [Header("관통력")]
    public int[] per;
}
