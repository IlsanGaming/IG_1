using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptble Object/EnemyData")]
public class EnemyData : ScriptableObject
{
    //�нú� ����
    [Header("#������ ���������ð�")]
    public float[] spawnTime;
    [Header("#������ ���ݷ�")]
    public float[] damage;
    [Header("������ �ִ�ü��")]
    public float[] health;
    [Header("#������ �̵��ӵ�")]
    public float[] speed;
    [Header("#�� ID")]
    public int id;


    [Header("#���� ���� ���ð�")]
    public float[] skillcool;
    [Header("#���� �����Ÿ�")]
    public float[] skilllength;
    [Header("#���� ����Ƚ��")]
    public float[] skillcount;
    [Header("#���� ���ط�")]
    public float[] skilldamage;
}
