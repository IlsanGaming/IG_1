using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptble Object/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("����ü �ӵ�(���Ÿ� ����)")]
    public float[] bulletspeed;
    [Header("����ü �ӵ�(����)")]
    public float[] speed;
    [Header("�����")]
    public int[] per;
}
