using UnityEngine;

// �������� ���� ���� ������
public enum StageType
{
    Easy,
    Normal,
    Hard
}

[CreateAssetMenu(fileName = "MonsterDataTable", menuName = "Data/MonsterTable")]

// ���� ������ �迭
public class MonsterDataTable : ScriptableObject
{
    public MonsterData[] monsters;
}

// ���� ������ ������ ������ Ŭ����
[System.Serializable]
public class MonsterData
{
    public string monsterName; // ���� �̸�
    public StageType stageType; // �������� ����
    public int monsterHP; // ���� ü��
    public int rewardGold; // óġ ���� ���
    public GameObject monsterPrefab; // ���� ������
}

