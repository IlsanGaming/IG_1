using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnChancesData", menuName = "Scriptable Object/Spawn Chances Data")]
public class SpawnChancesData : ScriptableObject
{
    [System.Serializable]
    public struct LevelSpawnChances
    {
        [Header("# 현재레벨(int)")]
        public string levelName; // 레벨 이름 (Inspector에서 구분하기 쉽게 표시)
        [Header("# 요소별 스폰 확률")]
        [Range(0f, 1f)]
        public float[] chances; // 적별 출현 확률 (0~1)
    }

    [Header("# 레벨별 스폰 확률")]
    public List<LevelSpawnChances> spawnChancesList;

    // OnValidate는 Inspector 값이 변경될 때 자동으로 호출
    void OnValidate()
    {
        foreach (var levelChance in spawnChancesList)
        {
            float total = 0f;
            foreach (float chance in levelChance.chances)
                total += chance;

            if (total > 1f)
            {
                Debug.LogWarning($"Spawn chances for level '{levelChance.levelName}' exceed 1.0! Current total: {total}");
            }
        }
    }
}