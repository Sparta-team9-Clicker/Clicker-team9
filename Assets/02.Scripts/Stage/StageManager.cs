using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public Transform spawnPoint; // ���Ͱ� ������ ��ġ
    public MonsterDataTable monsterDataTable; // ���� ������ ���̺�
    private List<MonsterData> monsters; // ���� �������� ���� ����Ʈ
    public StageType currentStage; // ���� �������� Ÿ��
    public TextMeshProUGUI stageName; // �������� �̸��� ǥ���ϴ� UI
    public TextMeshProUGUI killcountText; // ���� óġ�� ���� �� UI
    public TextMeshProUGUI monsterToKillCountUI; // ��ǥ óġ ���� �� UI
    private int killCount; // óġ�� ���� ��
    private int monsterToKillCount; // óġ�ؾ� �ϴ� ���� ��
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

        // ���� ���������� �ش��ϴ� ���͸� ����Ʈ�� �߰�
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

        // �������� ���� UI ������Ʈ
        UpdateStageName();
        killcountText.text = killCount.ToString();
        monsterToKillCountUI.text = monsterToKillCount.ToString();

        // ���� ����
        SpawnMonster();
    }

    private void SpawnMonster()
    {
        // ������ ���� ����
        MonsterData selectedMonster = monsters[Random.Range(0, monsters.Count)];
        
        if (selectedMonster.monsterPrefab == null)
        {
            return;
        }

        // ���� ���� �� ��ġ ����
        GameObject spawnedMonster = Instantiate(selectedMonster.monsterPrefab, spawnPoint.position, Quaternion.identity);
        
        // ���� ���� ���� �� Ÿ�� ����
        MonsterStatus monsterStatus = spawnedMonster.GetComponent<MonsterStatus>();
        if (monsterStatus != null)
        {
            monsterStatus.SetMonsterData(selectedMonster);
            click.SetTarget(monsterStatus);
        }

    }

    public void OnMonsterKilled()
    {
        killCount++; // óġ�� ���� �� ����
        killcountText.text = killCount.ToString(); // UI�� �ݿ�

        // ��ǥ óġ �� �޼��ϸ� �������� ���� �Ǵ� Ŭ����
        if (killCount >= monsterToKillCount)
        {
            if (currentStage == StageType.Hard)
            {
                // Hard �������� Ŭ�����ϸ� BGM ���� �� ������ �̵�
                AudioManager.instance.StopBgm();
                AudioManager.instance.PlaySfx(AudioManager.Sfxs.Clear);
                SceneLoad.instance.ChangeScene("EndingScene");
            }
            else
            {
                // ���� ���������� ��ȯ
                StartCoroutine(SceneLoad.instance.TransitionStage());
            }
        }
        else
        {
            // ��ǥ óġ ���� �޼����� �ʾҴٸ� ���� ����
            SpawnMonster();
        }
    }

    public void NextStage()
    {
        // �ϵ� ���������� ������ ����
        if (currentStage == StageType.Hard)
        {
            return;
        }

        // óġ�� ���� �� �ʱ�ȭ
        killCount = 0;

        // ���� ���������� ����
        currentStage = (StageType)(((int)currentStage + 1) % 3);

        StageBgm(); // �������� BGM ����
        monsters.Clear(); // ���� ���� ����Ʈ �ʱ�ȭ
        UpdateStageName(); // �������� UI ������Ʈ

        // ���ο� ���������� �´� ���� ����Ʈ �籸��
        foreach (var monster in monsterDataTable.monsters)
        {
            if (monster.stageType == currentStage)
                monsters.Add(monster);
        }

        if (monsters.Count == 0) return;

        // UI ������Ʈ
        killcountText.text = killCount.ToString();
        monsterToKillCountUI.text = monsterToKillCount.ToString();

        // ���ο� ���� ����
        SpawnMonster();
    }
    private void UpdateStageName()
    {
        if (stageName == null)
        {
            return;
        }

        // ���� ���������� ���� UI ���� �� ��ǥ óġ �� ����
        switch (currentStage)
        {
            case StageType.Easy:
                stageName.text = "1. ������������";
                monsterToKillCount = 5;
                break;
            case StageType.Normal:
                stageName.text = "2. ������������";
                monsterToKillCount = 6;
                break;
            case StageType.Hard:
                stageName.text = "3. ��������";
                monsterToKillCount = 1;
                break;
        }
    }

    public void StageBgm()
    {
        // ���������� ���� BGM ����
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
