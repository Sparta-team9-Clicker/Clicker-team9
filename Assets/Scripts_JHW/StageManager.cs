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
            click.SetTarget(monsterStatus);
        }

    }

    public void OnMonsterKilled()
    {
        killCount++;
        killcountText.text = killCount.ToString();

        if (killCount >= monsterToKillCount)
        {
            Debug.Log("���̵��ξƿ� ȿ�� ����");
            SceneLoad.instance.StartCoroutine(SceneLoad.instance.TransitionStage());
            Debug.Log("��");
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
        UpdateStageName();
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

        switch (currentStage)
        {
            case StageType.Easy:
                stageName.text = "������������";
                monsterToKillCount = 5;
                break;
            case StageType.Normal:
                stageName.text = "������������";
                monsterToKillCount = 6;
                break;
            case StageType.Hard:
                stageName.text = "��������";
                monsterToKillCount = 1;
                break;
        }
    }
}
