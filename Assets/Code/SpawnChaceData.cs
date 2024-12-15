using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnChancesData", menuName = "Scriptable Object/Spawn Chances Data")]
public class SpawnChancesData : ScriptableObject
{
    [System.Serializable]
    public struct LevelSpawnChances
    {
        [Header("# ���緹��(int)")]
        public string levelName; // ���� �̸� (Inspector���� �����ϱ� ���� ǥ��)
        [Header("# ��Һ� ���� Ȯ��")]
        [Range(0f, 1f)]
        public float[] chances; // ���� ���� Ȯ�� (0~1)
    }

    [Header("# ������ ���� Ȯ��")]
    public List<LevelSpawnChances> spawnChancesList;

    // OnValidate�� Inspector ���� ����� �� �ڵ����� ȣ��
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