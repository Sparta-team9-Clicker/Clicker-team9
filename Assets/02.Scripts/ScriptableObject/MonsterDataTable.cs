using UnityEngine;

// 스테이지 유형 정의 열거형
public enum StageType
{
    Easy,
    Normal,
    Hard
}

[CreateAssetMenu(fileName = "MonsterDataTable", menuName = "Data/MonsterTable")]

// 몬스터 데이터 배열
public class MonsterDataTable : ScriptableObject
{
    public MonsterData[] monsters;
}

// 몬스터 데이터 정보를 저장할 클래스
[System.Serializable]
public class MonsterData
{
    public string monsterName; // 몬스터 이름
    public StageType stageType; // 스테이지 유형
    public int monsterHP; // 몬스터 체력
    public int rewardGold; // 처치 보상 골드
    public GameObject monsterPrefab; // 몬스터 프리팹
}

