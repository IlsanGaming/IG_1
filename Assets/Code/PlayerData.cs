using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptble Object/PlayerData")]
public class PlayerData : ScriptableObject
{

    //패시브 스탯
    [Header("#레벨별 공격력 증가")]
    public float[] damage;
    [Header("#레벨별 치명타 확률 증가")]
    public float[] critical;
    [Header("#레벨별 재사용 대기시간 감소")]
    public float[] cool;
    [Header("#레벨별 방어력")]
    public float[] armor;
    [Header("레벨별 #최대체력")]
    public float[] health;
    [Header("#레벨별 체력재생")]
    public float[] healthRegen;
    [Header("#레벨별 지속시간")]
    public float[] duration;
    [Header("#레벨별 이동속도")]
    public float[] speed;


    //액티브 스탯
    [Header("#스킬1 이름")]
    public string skill1Name;
    [Header("#스킬1 설명")]
    [TextArea]
    public string skill1Dec; // 아이템 설명 (다중 라인 텍스트)
    [Header("#스킬1 재사용 대기시간")]
    public float[] skill1cool;
    [Header("#스킬1 사정거리")]
    public float[] skill1length;
    [Header("#스킬1 시전횟수")]
    public float[] skill1count;
    [Header("#스킬1 피해량")]
    public float[] skill1damage;



    [Header("#스킬2 이름")]
    public string skill2Name;
    [Header("#스킬2 설명")]
    [TextArea]
    public string skill2Dec; // 아이템 설명 (다중 라인 텍스트)
    [Header("#스킬2 재사용 대기시간")]
    public float[] skill2cool;
    [Header("#스킬2 사정거리")]
    public float[] skill2length;
    [Header("#스킬2 시전횟수")]
    public float[] skill2count;
    [Header("#스킬2 피해량")]
    public float[] skill2damage;



    [Header("#스킬3 이름")]
    public string skill3Name;
    [Header("#스킬3 설명")]
    [TextArea]
    public string skill3Dec; // 아이템 설명 (다중 라인 텍스트)
    [Header("#스킬3 재사용 대기시간")]
    public float[] skill3cool;
    [Header("#스킬3 사정거리")]
    public float[] skill3length;
    [Header("#스킬3 시전횟수")]
    public float[] skill3count;
    [Header("#스킬3 피해량")]
    public float[] skill3damage;



    [Header("#스킬4 이름")]
    public string skill4Name;
    [Header("#스킬4 설명")]
    [TextArea]
    public string skill4Dec; // 아이템 설명 (다중 라인 텍스트)
    [Header("#스킬4 재사용 대기시간")]
    public float[] skill4cool;
    [Header("#스킬4 사정거리")]
    public float[] skill4length;
    [Header("#스킬4 시전횟수")]
    public float[] skill4count;
    [Header("#스킬4 피해량")]
    public float[] skill4damage;



    [Header("#스킬5 이름")]
    public string skill5Name;
    [Header("#스킬5 설명")]
    [TextArea]
    public string skill5Dec; // 아이템 설명 (다중 라인 텍스트)
    [Header("#스킬5 재사용 대기시간")]
    public float[] skill5cool;
    [Header("#스킬5 사정거리")]
    public float[] skill5length;
    [Header("#스킬5 시전횟수")]
    public float[] skill5count;
    [Header("#스킬5 피해량")]
    public float[] skill5damage;
}
