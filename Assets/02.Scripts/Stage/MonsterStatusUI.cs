using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatusUI : MonoBehaviour
{
    private int curValue; // ���� ���� ü��
    private int maxValue; // ���� �ִ� ü��
    public TextMeshProUGUI monsterName; // ���� �̸� ǥ�� UI
    public Slider uiBar; // ���� ü���� ǥ���ϴ� UI

    //UI ���(ü�� ��, ���� �̸�)�� �ʱ�ȭ�ϴ� ����
    public void SetMonsterData(MonsterData monsterData)
    {
        if (monsterData != null)
        {
            maxValue = monsterData.monsterHP;
            curValue = maxValue;

            // UI ���� �ִ밪�� ���� ü�� ����ȭ
            uiBar.maxValue = maxValue;
            uiBar.value = curValue;

            // ���� �̸� ǥ��
            monsterName.text = monsterData.monsterName;
        }
    }

    // ü�� UI�� ������Ʈ�ϴ� �Լ�
    public void UpdateHP(int hp)
    {
        curValue = hp; // ���޹��� hp ������ ����
        uiBar.value = curValue; // UI ���� ���� ������Ʈ�Ͽ� ü�� ǥ��
    }
}
