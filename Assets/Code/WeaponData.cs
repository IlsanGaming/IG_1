using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptble Object/WeaponData")]
public class WeaponData : ScriptableObject
{
    //�нú� ����
    [Header("#������ ���������ð�")]
    public float[] speed;
    [Header("#������ ���ݷ�")]
    public float[] count;
}
