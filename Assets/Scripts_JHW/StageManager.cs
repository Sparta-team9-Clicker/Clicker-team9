using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public Transform spawnPoint;
    public MonsterDataTable monsterDataTable;
    private List<MonsterData> monsters;
    public StageType currentStage;
    public TextMeshProUGUI stageName;
    public TextMeshProUGUI killcountText;
    public TextMeshProUGUI monsterToKillCountUI;
    private int killCount;
    private int monsterToKillCount;

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
        UpdateStageName();
        killcountText.text = killCount.ToString();
        monsterToKillCountUI.text = monsterToKillCount.ToString();

        
        SpawnMonster();
    }

    public void SpawnMonster()
    {
        if (monsters.Count == 0)
        {
            return;
        }

        MonsterData selectedMonster = monsters[Random.Range(0, monsters.Count)];
        if (selectedMonster.monsterPrefab == null)
        {
            return;
        }

        GameObject spawnedMonster = Instantiate(selectedMonster.monsterPrefab, spawnPoint.position, Quaternion.identity);

        MonsterStatus monsterStatus = spawnedMonster.GetComponent<MonsterStatus>();
        if (monsterStatus != null)
        {
            monsterStatus.SetMonsterData(selectedMonster);
        }
    }

    public void OnMonsterKilled()
    {
       killCount++;

        if (killCount >= monsterToKillCount)
        {
            NextStage();
        }
        else
        {
            SpawnMonster();
        }
    }

    private void NextStage()
    {
        killCount = 0;
        currentStage = (StageType)(((int)currentStage + 1) % 3); 

        monsters.Clear();
        foreach (var monster in monsterDataTable.monsters)
        {
            if (monster.stageType == currentStage)
                monsters.Add(monster);
        }

        if (monsters.Count == 0)
        {
            return;
        }

        SpawnMonster();
    }
    private void UpdateStageName()
    {
        if (stageName == null)
        {
            return;
        }

        switch (currentStage)
        {
            case StageType.Easy:
                stageName.text = "苞老俩府公府";
                monsterToKillCount = 5;
                break;
            case StageType.Normal:
                stageName.text = "崔霓俩府公府";
                monsterToKillCount = 6;
                break;
            case StageType.Hard:
                stageName.text = "焊胶惑绢空";
                monsterToKillCount = 1;
                break;
        }
    }
}
