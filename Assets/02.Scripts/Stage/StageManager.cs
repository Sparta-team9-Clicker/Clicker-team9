using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public Transform spawnPoint; // 몬스터가 스폰될 위치
    public MonsterDataTable monsterDataTable; // 몬스터 데이터 테이블
    private List<MonsterData> monsters; // 현재 스테이지 몬스터 리스트
    public StageType currentStage; // 현재 스테이지 타입
    public TextMeshProUGUI stageName; // 스테이지 이름을 표시하는 UI
    public TextMeshProUGUI killcountText; // 현재 처치한 몬스터 수 UI
    public TextMeshProUGUI monsterToKillCountUI; // 목표 처치 몬스터 수 UI
    private int killCount; // 처치한 몬스터 수
    private int monsterToKillCount; // 처치해야 하는 몬스터 수
    public Click click;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (monsterDataTable == null || monsterDataTable.monsters.Length == 0)
        {
            return;
        }

        // 현재 스테이지에 해당하는 몬스터만 리스트에 추가
        monsters = new List<MonsterData>();
        foreach (var monster in monsterDataTable.monsters)
        {
            if (monster.stageType == currentStage)
                monsters.Add(monster);
        }

        if (monsters.Count == 0)
        {
            return;
        }

        // 스테이지 정보 UI 업데이트
        UpdateStageName();
        killcountText.text = killCount.ToString();
        monsterToKillCountUI.text = monsterToKillCount.ToString();

        // 몬스터 스폰
        SpawnMonster();
    }

    private void SpawnMonster()
    {
        // 랜덤한 몬스터 선택
        MonsterData selectedMonster = monsters[Random.Range(0, monsters.Count)];
        
        if (selectedMonster.monsterPrefab == null)
        {
            return;
        }

        // 몬스터 생성 및 위치 설정
        GameObject spawnedMonster = Instantiate(selectedMonster.monsterPrefab, spawnPoint.position, Quaternion.identity);
        
        // 몬스터 상태 설정 및 타겟 설정
        MonsterStatus monsterStatus = spawnedMonster.GetComponent<MonsterStatus>();
        if (monsterStatus != null)
        {
            monsterStatus.SetMonsterData(selectedMonster);
            click.SetTarget(monsterStatus);
        }

    }

    public void OnMonsterKilled()
    {
        killCount++; // 처치한 몬스터 수 증가
        killcountText.text = killCount.ToString(); // UI에 반영

        // 목표 처치 수 달성하면 스테이지 변경 또는 클리어
        if (killCount >= monsterToKillCount)
        {
            if (currentStage == StageType.Hard)
            {
                // Hard 스테이지 클리어하면 BGM 정지 및 엔딩씬 이동
                AudioManager.instance.StopBgm();
                AudioManager.instance.PlaySfx(AudioManager.Sfxs.Clear);
                SceneLoad.instance.ChangeScene("EndingScene");
            }
            else
            {
                // 다음 스테이지로 전환
                StartCoroutine(SceneLoad.instance.TransitionStage());
            }
        }
        else
        {
            // 목표 처치 수를 달성하지 않았다면 몬스터 스폰
            SpawnMonster();
        }
    }

    public void NextStage()
    {
        // 하드 스테이지가 끝나면 종료
        if (currentStage == StageType.Hard)
        {
            return;
        }

        // 처치한 몬스터 수 초기화
        killCount = 0;

        // 다음 스테이지로 변경
        currentStage = (StageType)(((int)currentStage + 1) % 3);

        StageBgm(); // 스테이지 BGM 변경
        monsters.Clear(); // 기존 몬스터 리스트 초기화
        UpdateStageName(); // 스테이지 UI 업데이트

        // 새로운 스테이지에 맞는 몬스터 리스트 재구성
        foreach (var monster in monsterDataTable.monsters)
        {
            if (monster.stageType == currentStage)
                monsters.Add(monster);
        }

        if (monsters.Count == 0) return;

        // UI 업데이트
        killcountText.text = killCount.ToString();
        monsterToKillCountUI.text = monsterToKillCount.ToString();

        // 새로운 몬스터 스폰
        SpawnMonster();
    }
    private void UpdateStageName()
    {
        if (stageName == null)
        {
            return;
        }

        // 현재 스테이지에 따라 UI 변경 및 목표 처치 수 설정
        switch (currentStage)
        {
            case StageType.Easy:
                stageName.text = "1. 과일젤리무리";
                monsterToKillCount = 5;
                break;
            case StageType.Normal:
                stageName.text = "2. 달콤젤리무리";
                monsterToKillCount = 6;
                break;
            case StageType.Hard:
                stageName.text = "3. 보스상어왕";
                monsterToKillCount = 1;
                break;
        }
    }

    public void StageBgm()
    {
        // 스테이지에 따라 BGM 변경
        if (currentStage == StageType.Normal)
        {
            AudioManager.instance.PlayBgm(AudioManager.Bgms.Stage2);
        }
        else if (currentStage == StageType.Hard)
        {
            AudioManager.instance.PlayBgm(AudioManager.Bgms.Stage3);
        }
    }
}
