using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptble Object/PlayerData")]
public class PlayerData : ScriptableObject
{

    //�нú� ����
    [Header("#������ ���ݷ� ����")]
    public float[] damage;
    [Header("������ #�ִ�ü��")]
    public float[] health;
    [Header("#������ �̵��ӵ�")]
    public float[] speed;

    [Header("#��ų1 ���� ���ð�")]
    public float[] skill1cool;
}
