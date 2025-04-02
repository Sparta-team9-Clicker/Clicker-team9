using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatusUI : MonoBehaviour
{
    private int curValue; // ���� ������ ü��
    private int maxValue; // ������ �ִ� ü��
    public TextMeshProUGUI monsterName; // ���� �̸��� ǥ���ϴ� UI
    public Slider uiBar; // ���� ü���� ǥ���ϴ� UI

    // UI ��� �ʱ�ȭ
    public void SetMonsterDataUI(MonsterData monsterData)
    {
        if (monsterData != null)
        {
            maxValue = monsterData.monsterHP; // �ִ� ü�� ����
            curValue = maxValue; // �ִ� ü�� ����
            uiBar.maxValue = maxValue; // UI ���� �ִ밪�� ���� ü�� ����ȭ
            uiBar.value = curValue; 
            monsterName.text = monsterData.monsterName; // ���� �̸� ǥ��
        }
    }

    // ü�� UI ������Ʈ �Լ�
    public void UpdateHP(int hp)
    {
        curValue = hp; // ���� ü���� Hp������ ����
        uiBar.value = curValue; // UI ���� ���� ������Ʈ �Ͽ� ü�� ǥ��
    }
}
