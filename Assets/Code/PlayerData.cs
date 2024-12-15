using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptble Object/PlayerData")]
public class PlayerData : ScriptableObject
{

    //�нú� ����
    [Header("#������ ���ݷ� ����")]
    public float[] damage;
    [Header("#������ ġ��Ÿ Ȯ�� ����")]
    public float[] critical;
    [Header("#������ ���� ���ð� ����")]
    public float[] cool;
    [Header("#������ ����")]
    public float[] armor;
    [Header("������ #�ִ�ü��")]
    public float[] health;
    [Header("#������ ü�����")]
    public float[] healthRegen;
    [Header("#������ ���ӽð�")]
    public float[] duration;
    [Header("#������ �̵��ӵ�")]
    public float[] speed;


    //��Ƽ�� ����
    [Header("#��ų1 �̸�")]
    public string skill1Name;
    [Header("#��ų1 ����")]
    [TextArea]
    public string skill1Dec; // ������ ���� (���� ���� �ؽ�Ʈ)
    [Header("#��ų1 ���� ���ð�")]
    public float[] skill1cool;
    [Header("#��ų1 �����Ÿ�")]
    public float[] skill1length;
    [Header("#��ų1 ����Ƚ��")]
    public float[] skill1count;
    [Header("#��ų1 ���ط�")]
    public float[] skill1damage;



    [Header("#��ų2 �̸�")]
    public string skill2Name;
    [Header("#��ų2 ����")]
    [TextArea]
    public string skill2Dec; // ������ ���� (���� ���� �ؽ�Ʈ)
    [Header("#��ų2 ���� ���ð�")]
    public float[] skill2cool;
    [Header("#��ų2 �����Ÿ�")]
    public float[] skill2length;
    [Header("#��ų2 ����Ƚ��")]
    public float[] skill2count;
    [Header("#��ų2 ���ط�")]
    public float[] skill2damage;



    [Header("#��ų3 �̸�")]
    public string skill3Name;
    [Header("#��ų3 ����")]
    [TextArea]
    public string skill3Dec; // ������ ���� (���� ���� �ؽ�Ʈ)
    [Header("#��ų3 ���� ���ð�")]
    public float[] skill3cool;
    [Header("#��ų3 �����Ÿ�")]
    public float[] skill3length;
    [Header("#��ų3 ����Ƚ��")]
    public float[] skill3count;
    [Header("#��ų3 ���ط�")]
    public float[] skill3damage;



    [Header("#��ų4 �̸�")]
    public string skill4Name;
    [Header("#��ų4 ����")]
    [TextArea]
    public string skill4Dec; // ������ ���� (���� ���� �ؽ�Ʈ)
    [Header("#��ų4 ���� ���ð�")]
    public float[] skill4cool;
    [Header("#��ų4 �����Ÿ�")]
    public float[] skill4length;
    [Header("#��ų4 ����Ƚ��")]
    public float[] skill4count;
    [Header("#��ų4 ���ط�")]
    public float[] skill4damage;



    [Header("#��ų5 �̸�")]
    public string skill5Name;
    [Header("#��ų5 ����")]
    [TextArea]
    public string skill5Dec; // ������ ���� (���� ���� �ؽ�Ʈ)
    [Header("#��ų5 ���� ���ð�")]
    public float[] skill5cool;
    [Header("#��ų5 �����Ÿ�")]
    public float[] skill5length;
    [Header("#��ų5 ����Ƚ��")]
    public float[] skill5count;
    [Header("#��ų5 ���ط�")]
    public float[] skill5damage;
}
