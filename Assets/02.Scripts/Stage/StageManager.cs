using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public Transform spawnPoint; // 몬스터가 스폰될 위치
    public MonsterDataTable monsterDataTable; // 몬스터 데이터 테이블
    private List<MonsterData> monsters; // 현재 스테이지의 몬스터 리스트
    public StageType currentStage; // 현재 스테이지 타입
    public TextMeshProUGUI stageName; // 스테이지 이름 표시 UI
    public TextMeshProUGUI killcountText; // 현재 처치한 몬스터 수 UI
    public TextMeshProUGUI monsterToKillCountUI; // 목표 몬스터 수 UI
    private int killCount; // 현재 스테이지에서 처치한 몬스터 수
    private int monsterToKillCount; // 현재 스테이지의 목표 몬스터 수
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

        //스테이지 정보 UI 업데이트
        UpdateStageName();
        killcountText.text = killCount.ToString();
        monsterToKillCountUI.text = monsterToKillCount.ToString();

        // 첫 몬스터 스폰
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
        killCount++; // 몬스터 처치 수 증가
        killcountText.text = killCount.ToString(); // UI 업데이트

        // 목표 처치 수 달성하면 스테이지 변경 
        if (killCount >= monsterToKillCount)
        {
            // 하드 스테이지 클리어시 BGM 정지 및 엔딩 씬으로 이동
            if (currentStage == StageType.Hard)
            {
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
            // 목표 처치 미달성 시 몬스터 스폰
            SpawnMonster();
        }
    }

    public void NextStage()
    {
        if (currentStage == StageType.Hard)
        {
            return;
        }

        killCount = 0; // 처치한 몬스터 수 초기화
        currentStage = (StageType)(((int)currentStage + 1) % 3); // 다음 스테이지로 변경

        StageBgm();
        monsters.Clear(); // 기존 몬스터 리스트 초기화
        UpdateStageName(); // 스테이지 UI 업데이트

        // 새로운 스테이지 몬스터 리스트 생성
        foreach (var monster in monsterDataTable.monsters)
        {
            if (monster.stageType == currentStage)
                monsters.Add(monster);
        }

        if (monsters.Count == 0) return;
        killcountText.text = killCount.ToString();
        monsterToKillCountUI.text = monsterToKillCount.ToString();

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
