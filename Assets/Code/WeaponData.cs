using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptble Object/WeaponData")]
public class WeaponData : ScriptableObject
{
    //�нú� ����
    [Header("#����ü ����")]
    public int[] count;
    [Header("����ü �ӵ�(����)")]
    public float[] speed;
    [Header("����ü �ӵ�(���Ÿ� ����)")]
    public float[] bulletspeed;
    [Header("�����")]
    public int[] per;
}
